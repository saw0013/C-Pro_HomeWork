using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Unit18
{
    /// <summary>
    /// Сохранение информации в pdf файле
    /// </summary>
    internal class SaveToPdf : IFileRS
    {
        public string nameOfFile;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="NameOfFile"></param>
        public SaveToPdf(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="animal"></param>
        public void Delete(IAnimal animalRemove)
        {
            List<IAnimal> animals = Read();

            int page = 0;

            Font font = new Font(BaseFont.CreateFont("Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream($"{nameOfFile}New.pdf", FileMode.Create)); //Получение экземпляра класса PdfWriter
            doc.Open(); // Открытие документа

            //Цикл перебора животных и записи их в документ
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id != animalRemove.Id)
                {
                    Paragraph para = new Paragraph($"{animals[i].Id}#{animals[i].Name}#{animals[i].Height}#{animals[i].Weight}#{animals[i].TypeAnimal}", font);
                    doc.Add(para);
                    doc.NewPage();
                    page++;
                }
            }

            //Если мы удаляем последнего,
            //то удаляем тогда весь файл,
            //иначе удаляем старый файл и переназываем новый
            if (page == 0)
            {
                File.Delete($"{nameOfFile}.pdf");
            }
            else
            {
                doc.Close();
                File.Delete($"{nameOfFile}.pdf");
                File.Move($"{nameOfFile}New.pdf", $"{nameOfFile}.pdf");
            }
            
        }

        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> Read()
        {
            List<IAnimal> result = new List<IAnimal>();

            if (!File.Exists($"{nameOfFile}.pdf"))
            {
                return result;
            }

            // Открытие PDF файла для чтения
            using (var reader = new PdfReader($"{nameOfFile}.pdf"))
            {
                // Перебор страниц в PDF файле
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    // Извлечение текста со страницы
                    var pageContent = PdfTextExtractor.GetTextFromPage(reader, i);

                    // Разделение текста на строки
                    var lines = pageContent.Split('#');

                    // Записываем информацию
                    int animalId = int.Parse(lines[0]);
                    string animalName = lines[1];
                    int animalHeight = int.Parse(lines[2]);
                    int animalWeight = int.Parse(lines[3]);
                    string animalType = lines[4];

                    // Добавляем в результат животного
                    result.Add(AnimalFactory.GetAnimal(animalType, animalId, animalName, animalHeight, animalWeight));                    
                }
            }
            return result;
        }

        /// <summary>
        /// Сохранение или обновление файла
        /// </summary>
        /// <param name="animal"></param>
        public void SaveOrUpdate(IAnimal animal)
        {

            List<IAnimal> animals = Read();

            IAnimal animalUpdate = animals.Find(e => e.Id == animal.Id);

            //Шрифт, для русской кирилици
            Font font = new Font(BaseFont.CreateFont("Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);

            int id = 0;

            if (animalUpdate == null)
            {
                Debug.WriteLine("НЕ Обновляем данные");


                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream($"{nameOfFile}.pdf", FileMode.Create)); //Получение экземпляра класса PdfWriter
                doc.Open(); // Открытие документа

                //Цикл перебора животных и записи их в документ
                for (int i = 0; i < animals.Count; i++)
                {
                    Paragraph para = new Paragraph($"{animals[i].Id}#{animals[i].Name}#{animals[i].Height}#{animals[i].Weight}#{animals[i].TypeAnimal}", font);
                    doc.Add(para);
                    doc.NewPage();
                    id = animals[i].Id;
                }

                id++;

                //Создание нового животного и запись его в документ
                Paragraph paraNewAnimal = new Paragraph($"{id}#{animal.Name}#{animal.Height}#{animal.Weight}#{animal.TypeAnimal}", font);
                doc.Add(paraNewAnimal);

                //Закрытие документа
                doc.Close();
            }
            else
            {
                
                Debug.WriteLine("Обновляем данные");

                int animalId = animal.Id;

                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream($"{nameOfFile}New.pdf", FileMode.Create)); //Получение экземпляра класса PdfWriter
                doc.Open(); // Открытие документа

                //Цикл перебора животных и записи их в документ
                for (int i = 0; i < animals.Count; i++)
                {
                    if (animals[i].Id != animalUpdate.Id)
                    {
                        Paragraph para = new Paragraph($"{animals[i].Id}#{animals[i].Name}#{animals[i].Height}#{animals[i].Weight}#{animals[i].TypeAnimal}", font);
                        doc.Add(para);
                        id = animals[i].Id;
                    }
                    else
                    {
                        id++;
                        //Создание нового животного и запись его в документ
                        Paragraph paraNewAnimal = new Paragraph($"{id}#{animal.Name}#{animal.Height}#{animal.Weight}#{animal.TypeAnimal}", font);
                        doc.Add(paraNewAnimal);
                    }
                    doc.NewPage();
                }

                doc.Close();

                File.Delete($"{nameOfFile}.pdf");
                File.Move($"{nameOfFile}New.pdf", $"{nameOfFile}.pdf");
            }
        }   

        public override string ToString()
        {
            return "Save to pdf";
        }
    }
}
