using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Unit18.MVP
{
    public class Unit18Model : IModel
    {
        SaveToPdf saveToPdf = new SaveToPdf("Animals");
        SaveToText saveToText = new SaveToText("Animals");
        SaveToJson saveToJson = new SaveToJson("Animals");

        Repository repository = new Repository();

        public IAnimal createdAnimal;

        bool flagUpdate = false;

        public IFileRS[] GetStart()
        {
            return new IFileRS[]
            {
                saveToPdf,
                saveToText,
                saveToJson
            };
        }

        public void GVCellEditEnding()
        {
            flagUpdate = true;
        }

        public void GVCurrentCellChanged(IFileRS fileRSMode, IAnimal animal)
        {
            if (flagUpdate == false) return;

            repository.AddOrUpdateData(fileRSMode, animal);

            flagUpdate = false;
        }

        public List<IAnimal> MenuItemAddClick(IFileRS fileRSMode)
        {
            if (fileRSMode == null)
            {
                MessageBox.Show("Выберите тип сохранения, прежде чем создавать данные");
                return new List<IAnimal>();
            }

            AddDataAnimal addData = new AddDataAnimal(this);

            addData.ShowDialog();

            if (addData.DialogResult.Value)
            {
                repository.AddOrUpdateData(fileRSMode, createdAnimal);
            }

            return UpdateGrid(fileRSMode);
        }

        public List<IAnimal> MenuItemDeleteClick(IFileRS fileRSMode, IAnimal animal)
        {

            if (fileRSMode == null)
            {
                MessageBox.Show("Выберите тип сохранения, прежде чем удалять данные");
                return new List<IAnimal>();
            }

            if (animal == null) return UpdateGrid(fileRSMode);

            repository.DeleteData(animal, fileRSMode);

            return UpdateGrid(fileRSMode);
        }

        public List<IAnimal> SelectionChanged(IFileRS fileRSMode)
        {
            return UpdateGrid(fileRSMode);
        }

        public List<IAnimal> UpdateGrid(IFileRS fileRSMode)
        {
            if (fileRSMode == null) return new List<IAnimal>();

            return repository.ReadData(fileRSMode);
        }
    }
}
