using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    static class AnimalFactory
    {
        /// <summary>
        /// Возвращаем животного, введенного пользователем
        /// </summary>
        /// <param name="typeAnimal"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static IAnimal GetAnimal(string typeAnimal, int id, string name, int height, int weight)
        {
            switch (typeAnimal)
            {
                case "Земноводные": return new Amphibians(id, name, height, weight, typeAnimal);
                case "Птицы": return new Bird(id, name, height, weight, typeAnimal);
                case "Млекопитающие": return new Mammal(id, name, height, weight, typeAnimal);
                default: return new UserAnimal(id, name, height, weight, typeAnimal);    
            }
        }

    }
}
