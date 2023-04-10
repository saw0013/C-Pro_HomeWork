
namespace Unit18
{
    public interface Animal
    {
        int Id { get; set; }
        string Name { get; set; }
        int Height { get; set; }
        int Weight { get; set; }
        string TypeAnimal { get; set; }
    }

    public abstract class IAnimal : Animal
    {
        /// <summary>
        /// Индификатор животного
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя животного
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Рост животного
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Масса животного
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Тип животного
        /// </summary>
        public string TypeAnimal { get; set; }

        public IAnimal() { }

        public abstract override string ToString();
    }
}
