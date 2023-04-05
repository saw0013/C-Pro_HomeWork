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

namespace Unit16
{
    /// <summary>
    /// Логика взаимодействия для AddClientData.xaml
    /// </summary>
    public partial class AddClientData : Window
    {
        private AddClientData() { InitializeComponent(); }

        public AddClientData(DataRow row) : this()
        {
            CancelButton.Click += delegate { this.DialogResult = false; };
            AddButton.Click += delegate
            {
                row["lastName"] = lastName.Text;
                row["name"] = name.Text;
                row["middleName"] = middleName.Text;
                row["numberPhone"] = numberPhone.Text;
                row["emailAdress"] = Email.Text;
                this.DialogResult = !false;
            };

        }
    }
}
