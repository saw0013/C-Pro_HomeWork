using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Unit17
{
    /// <summary>
    /// Логика взаимодействия для AddClientData.xaml
    /// </summary>
    public partial class AddClientData : Window
    {
        public AddClientData() { InitializeComponent(); } 

        public AddClientData(ClientData clientData) : this()
        {
            //Подписываемся на события, и в зависимости нажатой кнопки выполняеми метод
            CancelButton.Click += delegate { this.DialogResult = false; };
            AddButton.Click += delegate
            {
                //Заполняем данные 
                clientData.lastName = lastName.Text;
                clientData.name = name.Text;
                clientData.middleName = middleName.Text;
                clientData.numberPhone = numberPhone.Text;
                clientData.email = Email.Text;
                this.DialogResult = !false;
            };

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lastName.Text != String.Empty && name.Text != String.Empty && middleName.Text != String.Empty && Email.Text != String.Empty) AddButton.IsEnabled = true;
            else AddButton.IsEnabled = false;
        }
    }
}
