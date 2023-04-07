using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Unit17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MSDataBaseEntities context;

        Random random = new Random();
        
        private bool flagUpdate;

        public MainWindow()
        {
            InitializeComponent();
            context = new MSDataBaseEntities();

            //Выгружаем данные с сервера на модель
            context.ClientData.Load();
            //Выгружаем данные с модели в DataGrid
            gridClient.ItemsSource = context.ClientData.Local.ToBindingList<ClientData>();
        }

        /// <summary>
        /// Добавление данных о клиенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClientClick(object sender, RoutedEventArgs e)
        {
            ClientData clientData = new ClientData();
            AddClientData add = new AddClientData(clientData);

            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                context.ClientData.Add(clientData); // Добавляем данные

                context.SaveChanges(); //Сохраняем изменения
                context.ClientData.Load(); //Выгружаем данные с сервера

                gridClient.ItemsSource = context.ClientData.Local.ToBindingList<ClientData>();
            }
        }

        /// <summary>
        /// Удаление данных о клиенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClientClick(object sender, RoutedEventArgs e)
        {
            ClientData clientDataRemove = gridClient.SelectedItem as ClientData;
            context.ClientData.Remove(clientDataRemove); //Удаляем данные 

            context.SaveChanges(); //Сохраняем изменения
            context.ClientData.Load(); //Выгружаем данные с сервера

            gridClient.ItemsSource = context.ClientData.Local.ToBindingList<ClientData>();
        }

        /// <summary>
        /// Добавление данных о продукте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddProductClick(object sender, RoutedEventArgs e)
        {
            ClientData clientData = gridClient?.SelectedItem as ClientData;

            if (clientData == null) return;

            ProductData productData = new ProductData();
            AddProductData add = new AddProductData(productData);

            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                productData.email = clientData.email;
                productData.productCode = $"#{random.Next(1,1000)}";

                context.ProductData.Add(productData); // Добавляем данные

                context.SaveChanges(); //Сохраняем изменения
                context.ProductData.Load(); //Выгружаем данные с сервера

                gridClientProduct.ItemsSource = GetClientProduct();
            }
        }

        /// <summary>
        /// Удаление данных о продукте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteProductClick(object sender, RoutedEventArgs e)
        {
            ProductData productData = gridClientProduct.SelectedItem as ProductData;
            context.ProductData.Remove(productData); //Удаляем данные 

            context.SaveChanges(); //Сохраняем изменения
            gridClientProduct.ItemsSource = GetClientProduct();
        }

        /// <summary>
        /// Событие, происходящие при начале изменения ClientGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentClientCellChanged(object sender, EventArgs e)
        {
            if (flagUpdate == false) return;

            ClientData clientData = gridClient.SelectedItem as ClientData;

            context.ClientData.AddOrUpdate(clientData); // Обновляем данные клиента

            context.SaveChanges(); //Сохраняем изменения

            context.ClientData.Load(); //Выгружаем данные с сервера
            gridClient.ItemsSource = context.ClientData.Local.ToBindingList<ClientData>();

            flagUpdate = false;
        }

        /// <summary>
        /// Событие, происходящие при оканчание изменения ClientGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellClientEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            flagUpdate = true;
        }

        /// <summary>
        /// Событие происходящие при изменения выделения dataGridClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridClientProduct.ItemsSource = GetClientProduct();
        }

        /// <summary>
        /// Получаем все товары, выбранного клиента
        /// </summary>
        /// <returns></returns>
        private List<ProductData> GetClientProduct()
        {
            ClientData clientData = gridClient?.SelectedItem as ClientData;

            if (clientData == null) return null;

            context.ProductData.Load(); //Выгружаем данные с сервера

            List<ProductData> res = context.ProductData.Where(e => e.email.Contains(clientData.email)).ToList(); //Находим продукт, по eamil

            return res; 
        }
    }

}

