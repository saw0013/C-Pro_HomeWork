using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    internal interface IView
    {
        IFileRS fileRS { get; }
        IAnimal selectedAnimal { get; }

        List<IAnimal> animals { set; }
        IFileRS[] fileRSMode { set; }
    }
}
