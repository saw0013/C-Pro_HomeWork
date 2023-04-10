using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    public interface IFileRS
    {
        void SaveOrUpdate(IAnimal animal);
        List<IAnimal> Read();
        void Delete(IAnimal animal);
    }
}
