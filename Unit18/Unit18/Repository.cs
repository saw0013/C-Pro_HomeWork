using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    internal class Repository
    {
        /// <summary>
        /// Добавление или обновление данных
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="modeRS"></param>
        public void AddOrUpdateData(IFileRS modeRS, IAnimal animal)
        {
            var FileRS = new FileRS(modeRS);

            FileRS.SaveOrUpdateFile(animal);
        }

        /// <summary>
        /// Чтение данных
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="modeRS"></param>
        public List<IAnimal> ReadData(IFileRS modeRS)
        {
            var FileRS = new FileRS(modeRS);

            return FileRS.ReadFile();
        }

        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="modeRS"></param>
        public void DeleteData(IAnimal animal , IFileRS modeRS)
        {
            var FileRS = new FileRS(modeRS);

            FileRS.DeleteFile(animal);
        }
    }
}
