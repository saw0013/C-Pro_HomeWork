using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System;

namespace Unit18
{
    /// <summary>
    /// Сохранение информации в json файле
    /// </summary>
    internal class SaveToJson : IFileRS
    {
        private string nameOfFile;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="NameOfFile"></param>

        public SaveToJson(string NameOfFile)
        {
            this.nameOfFile = NameOfFile;
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="animal"></param>
        public void Delete(IAnimal animal)
        {
            List<IAnimal> animals = Read(); // Читаем данные

            File.Delete($"{nameOfFile}.json"); // Удаляем файл

            for (int i = 0; i < animals.Count; i++) // Перезаписываем всех,
                                                    // кроме животного, которого хотим удалить
            {
                if (animals[i].Id != animal.Id)
                {
                    SaveOrUpdate(animals[i]); // Сохраняем данные в файл
                }
            }
        }

        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> Read()
        {
            List<IAnimal> result = new List<IAnimal>();

            if (!File.Exists($"{nameOfFile}.json"))
            {
                return result;
            }

            using (StreamReader file = File.OpenText($"{nameOfFile}.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                // Чтение файла и десериализация данных
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject) // Если начало объекта
                    {
                        // Предварительные данные
                        int id = 0, height = 0, weight = 0;
                        string name = "", type = "";
                        while (reader.Read()) // Читаем текущий объект
                        {
                            if (reader.TokenType == JsonToken.PropertyName) // Если это имя свойства
                            {
                                string propertyName = (string)reader.Value; // Получаем имя свойства

                                switch (propertyName) // Проверяем, какое свойство встретилось и читаем его значение
                                {
                                    case "Id":
                                        id = reader.ReadAsInt32() ?? 0; // Присваиваем id
                                        break;
                                    case "Name":
                                        name = reader.ReadAsString(); // Присваиваем имя
                                        break;
                                    case "Height":
                                        height = reader.ReadAsInt32() ?? 0; // Присваиваем высоту
                                        break;
                                    case "Weight":
                                        weight = reader.ReadAsInt32() ?? 0; // Присваиваем вес
                                        break;
                                    case "TypeAnimal":
                                        type = reader.ReadAsString(); // Присваиваем тип животного
                                        break;
                                    default:
                                        reader.Skip(); // Если свойство не подходит, пропускаем
                                        break;
                                }
                            }
                            else if (reader.TokenType == JsonToken.EndObject) // Если объект закончился
                            {
                                IAnimal animal = AnimalFactory.GetAnimal(type, id, name, height, weight); // Создаем новый объект животного
                                result.Add(animal); // Добавляем животное в список
                                break; // Выходим из цикла
                            }
                        }                        
                    }
                }
            }

            return result; // Возвращаем список животных.
        }

        /// <summary>
        /// Сохранение или обновление файла
        /// </summary>
        /// <param name="animal"></param>
        public void SaveOrUpdate(IAnimal animal)
        {
            // Чтение данных из файла
            List<IAnimal> animals = Read();
            IAnimal animalToUpdate = animals.Find(e => e.Id == animal.Id);

            JArray jsonArray = new JArray();

            if (animalToUpdate == null)
            {
                int maxId = 0;

                if (File.Exists($"{nameOfFile}.json")) // Если файл уже существует
                {
                    using (StreamReader file = File.OpenText($"{nameOfFile}.json"))
                    {
                        string jsonContent = file.ReadToEnd(); // Читаем содержимое файла
                        jsonArray = JArray.Parse(jsonContent); // Преобразуем содержимое в JArray
                        maxId = jsonArray.Max(obj => (int)obj["Id"]); // Находим максимальный id в массиве
                    }
                }

                // Создаем новый объект животного и добавляем его в массив
                JObject _animal = new JObject();
                _animal["Id"] = ++maxId;
                _animal["Name"] = animal.Name;
                _animal["Height"] = animal.Height;
                _animal["Weight"] = animal.Weight;
                _animal["TypeAnimal"] = animal.TypeAnimal;
                jsonArray.Add(_animal);

                // Записываем обновленные данные в файл
                using (StreamWriter file = File.CreateText($"{nameOfFile}.json"))
                {
                    file.Write(jsonArray.ToString());
                }
            }
            else
            {
                string json = File.ReadAllText($"{nameOfFile}.json"); // Читаем содержимое файла
                JArray jsonArrayUpdate = JArray.Parse(json); // Преобразуем содержимое в JArray

                foreach (JObject animalObject in jsonArrayUpdate) // Перебираем объекты в массиве
                {
                    int id = (int)animalObject["Id"]; // Получаем id текущего объекта

                    if (id == animal.Id) // Если id соответствует обновляемому животному
                    {
                        // Обновляем данные животного в объекте
                        animalObject["Name"] = animal.Name;
                        animalObject["Height"] = animal.Height;
                        animalObject["Weight"] = animal.Weight;
                        animalObject["TypeAnimal"] = animal.TypeAnimal;
                        break;
                    }
                }

                string output = JsonConvert.SerializeObject(jsonArrayUpdate, Formatting.Indented); // Преобразуем JArray в JSON
                File.WriteAllText($"{nameOfFile}.json", output); // Записываем обновленные данные в файл
            }
        }

        public override string ToString()
        {
            return "Save to json";
        }
    }
}
