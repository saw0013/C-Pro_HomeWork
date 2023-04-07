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
    /// Логика взаимодействия для AddProductData.xaml
    /// </summary>
    public partial class AddProductData : Window
    {
        public AddProductData() { InitializeComponent(); }

        public AddProductData(ProductData productData) : this()
        {
            //Подписываемся на события, и в зависимости нажатой кнопки выполняеми метод
            CancelButton.Click += delegate { this.DialogResult = false; };
            AddButton.Click += delegate
            {
                //Заполняем данные 
                productData.nameProduct = productName.Text;
                this.DialogResult = !false;
            };

        }

        private void productName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productName.Text != null) AddButton.IsEnabled = true;
            else AddButton.IsEnabled = false;
        }
    }
}
