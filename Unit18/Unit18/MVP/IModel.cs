using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    internal interface IModel
    {
        void GVCurrentCellChanged(IFileRS fileRSMode, IAnimal animal);
        void GVCellEditEnding();
        List<IAnimal> MenuItemAddClick(IFileRS fileRSMode);
        List<IAnimal> MenuItemDeleteClick(IFileRS fileRSMode, IAnimal animal);
        List<IAnimal> SelectionChanged(IFileRS fileRSMode);
        List<IAnimal> UpdateGrid(IFileRS fileRSMode);
        IFileRS[] GetStart();
    }
}
