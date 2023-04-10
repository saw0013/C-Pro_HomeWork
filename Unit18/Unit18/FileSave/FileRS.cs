using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    internal class FileRS 
    {
        public IFileRS Mode { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="Method"></param>
        public FileRS (IFileRS Method)
        {
            this.Mode = Method;
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="animal"></param>
        public void DeleteFile(IAnimal animal)
        {
            Mode.Delete(animal);
        }

        /// <summary>
        /// Чтение файла
        /// </summary>
        /// <returns></returns>
        public List<IAnimal> ReadFile()
        {
            return Mode.Read();
        }

        /// <summary>
        /// Добавление или обнавление данных
        /// </summary>
        /// <param name="animal"></param>
        public void SaveOrUpdateFile(IAnimal animal)
        {
           Mode.SaveOrUpdate(animal);
        }
    }
}
