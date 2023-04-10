using System;
using System.Windows;
using System.Windows.Controls;
using Unit18.MVP;

namespace Unit18
{
    /// <summary>
    /// Логика взаимодействия для AddDataAnimal.xaml
    /// </summary>
    public partial class AddDataAnimal : Window
    {
        public IAnimal animal;

        public AddDataAnimal() { InitializeComponent(); }

        public AddDataAnimal(Unit18Model model) : this() 
        {

            //Подписываемся на события, и в зависимости нажатой кнопки выполняеми метод
            CancelButton.Click += delegate { this.DialogResult = false; };
            AddButton.Click += delegate
            {
                string _Name = name.Text;
                int _Height = int.Parse(Height.Text);
                int _Weight = int.Parse(Weight.Text);
                string _TypeAnimal = TypeAnimal.Text;

                IAnimal animal = AnimalFactory.GetAnimal(_TypeAnimal, 0, _Name, _Height, _Weight);

                model.createdAnimal = animal;

                this.DialogResult = !false;
            };

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (name.Text != String.Empty && Height.Text != String.Empty && Weight.Text != String.Empty && TypeAnimal.Text != String.Empty) AddButton.IsEnabled = true;
            else AddButton.IsEnabled = false;
        }
    }
}
