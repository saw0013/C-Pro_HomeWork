﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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
            //Подписываемся на события, и в зависимости нажатой кнопки выполняеми метод
            CancelButton.Click += delegate { this.DialogResult = false; };
            AddButton.Click += delegate
            {
                //Заполняем данные 
                row["lastName"] = lastName.Text;
                row["name"] = name.Text;
                row["middleName"] = middleName.Text;
                row["numberPhone"] = numberPhone.Text;
                row["email"] = Email.Text;
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
