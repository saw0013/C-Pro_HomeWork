using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    /// <summary>
    /// Сохранение информации в text файле
    /// </summary>
    internal class SaveToText : IFileRS
    {
        private string nameOfFile;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="NameOfFile"></param>
        public SaveToText(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="animal"></param>
        public void Delete(IAnimal animal)
        {
            byte existingRows = 1;

            // считываем количество строк в файле, чтобы определить id животного
            using (StreamReader sr = new StreamReader($"{nameOfFile}.txt", Encoding.Unicode))
            {
                sr.ReadLine();

                while (sr.ReadLine() != null)
                {
                    existingRows++;
                }
            }

            List<IAnimal> animals = Read();

            //Записываем данные в файл
            using (StreamWriter sw = new StreamWriter($"{nameOfFile}New.txt", true, Encoding.Unicode))
            {
                sw.WriteLine("Животные");

                for (int i = 0; i < animals.Count; i++)
                {
                    if (animals[i].Id != animal.Id)
                    {
                        sw.WriteLine($"{animals[i].Id}#{animals[i].Name}#{animals[i].Height}#{animals[i].Weight}#{animals[i].TypeAnimal}");
                    }
                }
            }


            File.Delete($"{nameOfFile}.txt");
            File.Move($"{nameOfFile}New.txt", $"{nameOfFile}.txt");
        }

        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> Read()
        {
            List<IAnimal> result = new List<IAnimal>();

            if (!File.Exists($"{nameOfFile}.txt"))
            {
                return result;
            }

            //Считываем данные с файла, пока строка не окажется пустой
            using (StreamReader sr = new StreamReader($"{nameOfFile}.txt", Encoding.Unicode))
            {
                string line;
                sr.ReadLine();
                //Читаем каждую строчку 
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    IAnimal animal = AnimalFactory.GetAnimal(data[4], int.Parse(data[0]), data[1], int.Parse(data[2]), int.Parse(data[3]));
                    result.Add(animal);
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
            IAnimal animalToUpdate = animals.Find(e => e.Id == animal.Id);

            byte id = 1;

            if (!File.Exists($"{nameOfFile}.txt"))
            {
                using (StreamWriter sw = new StreamWriter($"{nameOfFile}.txt", true, Encoding.Unicode))
                {
                    sw.WriteLine("Животные");
                }
            }
            else
            {

                // считываем количество строк в файле, чтобы определить id животного
                using (StreamReader sr = new StreamReader($"{nameOfFile}.txt", Encoding.Unicode))
                {
                    sr.ReadLine();

                    while (sr.ReadLine() != null)
                    {
                        id++;
                    }
                }
            }

            if (animalToUpdate == null)
            {
                //Записываем данные в файл
                using (StreamWriter sw = new StreamWriter($"{nameOfFile}.txt", true, Encoding.Unicode))
                {
                    sw.WriteLine($"{id}#{animal.Name}#{animal.Height}#{animal.Weight}#{animal.TypeAnimal}");
                }
            }
            else
            {
                //Записываем данные в файл
                using (StreamWriter sw = new StreamWriter($"{nameOfFile}New.txt", true, Encoding.Unicode))
                {
                    sw.WriteLine("Животные");

                    for (int i = 0; i < animals.Count; i++)
                    {
                        if (animals[i].Id != animalToUpdate.Id)
                        {
                            sw.WriteLine($"{animals[i].Id}#{animals[i].Name}#{animals[i].Height}#{animals[i].Weight}#{animals[i].TypeAnimal}");
                        }
                        else
                        {
                            sw.WriteLine($"{animal.Id}#{animal.Name}#{animal.Height}#{animal.Weight}#{animal.TypeAnimal}");
                        }
                    }                    
                }

                File.Delete($"{nameOfFile}.txt");
                File.Move($"{nameOfFile}New.txt", $"{nameOfFile}.txt");
            }
        }

        public override string ToString()
        {
            return "Save to text";
        }
    }
}
