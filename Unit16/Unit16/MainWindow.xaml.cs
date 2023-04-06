using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Unit16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();

        SqlConnection clientConnection;
        SqlDataAdapter clientAdapter;
        DataTable clientDataTable;
        DataRowView clientRow;

        SqlConnection productConnection;
        SqlDataAdapter productAdapter;
        DataTable productDataTable;
        DataRowView productRow;

        public MainWindow() { InitializeComponent(); Preparing(); }

        /// <summary>
        /// Инициализация всех источников данных
        /// </summary>
        private void Preparing()
        {
            #region ClientData

            #region Init ClientData

            //Инициализируем доступ к источнику данных 
            var clientDataConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "ClientData",
            };

            clientConnection = new SqlConnection(clientDataConnectionStringBuilder.ConnectionString);
            clientDataTable = new DataTable();
            clientAdapter = new SqlDataAdapter();

            #endregion

            #region select

            //Команда SELECT
            var sql = @"SELECT * FROM DataClient Order By DataClient.id";
            clientAdapter.SelectCommand = new SqlCommand(sql, clientConnection);

            #endregion

            #region insert
            //Команда INSERT
            sql = @"INSERT INTO DataClient (lastName,  name,  middleName, numberPhone, email) 
                                 VALUES (@lastName,  @name,  @middleName, @numberPhone, @email); SET @id = @@IDENTITY;";

            clientAdapter.InsertCommand = new SqlCommand(sql, clientConnection);

            clientAdapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").Direction = ParameterDirection.Output;
            clientAdapter.InsertCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 20, "lastName");
            clientAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20, "name");
            clientAdapter.InsertCommand.Parameters.Add("@middleName", SqlDbType.NVarChar, 20, "middleName");
            clientAdapter.InsertCommand.Parameters.Add("@numberPhone", SqlDbType.NVarChar, 20, "numberPhone");
            clientAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 20, "email");

            #endregion

            #region update
            //Команда UPDATE
            sql = @"UPDATE DataClient SET 
                           lastName = @lastName,
                           name = @name, 
                           middleName = @middleName,
                           numberPhone = @numberPhone,
                           email = @email
                    WHERE id = @id";

            clientAdapter.UpdateCommand = new SqlCommand(sql, clientConnection);
            clientAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;
            clientAdapter.UpdateCommand.Parameters.Add("@lastName", SqlDbType.NVarChar, 20, "lastName");
            clientAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20, "name");
            clientAdapter.UpdateCommand.Parameters.Add("@middleName", SqlDbType.NVarChar, 20, "middleName");
            clientAdapter.UpdateCommand.Parameters.Add("@numberPhone", SqlDbType.NVarChar, 20, "numberPhone");
            clientAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 20, "email");
            #endregion

            #region delete
            // Команда DELETE
            sql = "DELETE FROM DataClient WHERE id = @id";

            clientAdapter.DeleteCommand = new SqlCommand(sql, clientConnection);
            clientAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            #endregion

            //Предварительно заполняем
            clientAdapter.Fill(clientDataTable);
            gridClient.DataContext = clientDataTable.DefaultView;

            #endregion

            #region ProductData

            #region Init ProductData

            //Инициализируем доступ к источнику данных
            var productDataConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "ProductData",
            };

            productConnection = new SqlConnection(productDataConnectionStringBuilder.ConnectionString);
            productDataTable = new DataTable();
            productAdapter = new SqlDataAdapter();

            #endregion

            #region select

            //Команда SELECT
            sql = @"SELECT * FROM ProductData Order By ProductData.id";
            productAdapter.SelectCommand = new SqlCommand(sql, productConnection);

            #endregion

            #region insert

            //Команда INSERT
            sql = @"INSERT INTO ProductData (email, codeProduct, nameProduct) 
                     VALUES (@email, @codeProduct, @nameProduct);";


            productAdapter.InsertCommand = new SqlCommand(sql, productConnection);
            
            productAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 20, "email");
            productAdapter.InsertCommand.Parameters.Add("@codeProduct", SqlDbType.NVarChar, 20, "codeProduct");
            productAdapter.InsertCommand.Parameters.Add("@nameProduct", SqlDbType.NVarChar, 20, "nameProduct");
            #endregion

            #region delete
            // Команда DELETE
            productAdapter.DeleteCommand = new SqlCommand("DELETE FROM ProductData WHERE id = @id", productConnection);

            productAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");

            #endregion

            //Предварительно заполняем
            productAdapter.Fill(productDataTable);
            gridClientProduct.DataContext = productDataTable.DefaultView;

            #endregion
        }

        /// <summary>
        /// Добавление данных о клиенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClientClick(object sender, RoutedEventArgs e)
        {
            DataRow r = clientDataTable.NewRow(); // Создаем новую строку
            AddClientData add = new AddClientData(r); // Через другое окно заставляем записать данные 
            add.ShowDialog(); 


            if (add.DialogResult.Value) // Если мы нажали "Добавить", то добавляем данные
            {
                clientDataTable.Rows.Add(r);
                clientAdapter.Update(clientDataTable);
            }
        }

        /// <summary>
        /// Удаление данных о клиенте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClientClick(object sender, RoutedEventArgs e)
        {
            clientRow = (DataRowView)gridClient.SelectedItem;
            clientRow.Row.Delete(); // Удаляем данные выбранного клиента 
            clientAdapter.Update(clientDataTable); 
        }

        /// <summary>
        /// Добавление данных о продукте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddProductClick(object sender, RoutedEventArgs e)
        {
            if (gridClient.SelectedItem == null) return;

            //Получаем почту клиента, который был выделен
            DataRowView row = (DataRowView)gridClient.SelectedItem;
            string email = row["Email"].ToString();

            // Записываем предварительные данные
            DataRow r = productDataTable.NewRow();
            r["email"] = email;
            r["codeProduct"] = $"#{random.Next(1, 1000)}";
            AddProductData add = new AddProductData(r);
            add.ShowDialog();


            if (add.DialogResult.Value) // Если мы нажали добавить, то мы добавляем данные 
            {
                productDataTable.Rows.Add(r);
                productAdapter.Update(productDataTable);
            }

            //Обновляем dataGridProduct
            gridClientProduct.ItemsSource = GetClientProduct();
        }

        /// <summary>
        /// Удаление данных о продукте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteProductClick(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)gridClientProduct.SelectedItem;
            if (selectedRow != null)
            {
                //Удаляем выбранный товар
                int productId = (int)selectedRow["id"];
                string sql = "DELETE FROM ProductData WHERE id = @productId";
                SqlCommand command = new SqlCommand(sql, productConnection);
                command.Parameters.AddWithValue("@productId", productId);

                productConnection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Получаем кол-во затронутых строк
                productConnection.Close();

                if (rowsAffected > 0)
                {
                    // Обновляем содержимое DataGrid
                    productDataTable.Clear();
                    productAdapter.Fill(productDataTable);
                    gridClientProduct.ItemsSource = GetClientProduct();
                }
            }
        }

        /// <summary>
        /// Событие, происходящие при начале изменения ClientGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentClientCellChanged(object sender, EventArgs e)
        {
            if (clientRow == null) return;
            clientRow.EndEdit();
            clientAdapter.Update(clientDataTable);
        }

        /// <summary>
        /// Событие, происходящие при оканчание изменения ClientGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellClientEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            clientRow = (DataRowView)gridClient.SelectedItem;
            clientRow.BeginEdit();
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
        private DataView GetClientProduct()
        {
            // Получить выделенную строку в dataGrid с клиентами
            DataRowView selectedClient = (DataRowView)gridClient.SelectedItem;

            if (selectedClient == null) return null;

            // Получить значение email-адреса выделенного клиента
            string email = selectedClient["email"].ToString();

            // Используя email-адрес, выполнить запрос SQL для выборки всех продуктов, связанных с этим клиентом
            string sql = "SELECT * FROM ProductData WHERE email = @email";
            SqlCommand command = new SqlCommand(sql, productConnection);
            command.Parameters.AddWithValue("@email", email);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable productsTable = new DataTable();
            adapter.Fill(productsTable);

            // Возвращаем продукты
            return productsTable.DefaultView;
        }
    }
}
