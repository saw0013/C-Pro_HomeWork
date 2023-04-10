using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18
{
    internal class Bird : IAnimal
    {

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">Индификатор</param>
        /// <param name="name">Имя</param>
        /// <param name="height">Рост</param>
        /// <param name="waight">Масса</param>
        public Bird(int id, string name, int height, int weight, string typeAnimal)
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
            TypeAnimal = typeAnimal;
        }
        public override string ToString()
        {
            return $"{Id}|{Name}|{Height}|{Weight}|{TypeAnimal}";
        }
    }
}
