using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Unit16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con1;
        SqlDataAdapter da;
        DataTable dt;
        DataRowView row;

        public MainWindow()  {InitializeComponent(); Preparing();}

        private void Preparing()
        {
            #region Init LocalDB
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB", 
                InitialCatalog = "msdb",
                UserID = "Admin",
                Password = "Password",
            };

            con1 = new SqlConnection(connectionStringBuilder.ConnectionString);
            dt = new DataTable();
            da = new SqlDataAdapter();

            con1.StateChange +=
                (s, e) => {
                    MessageBox.Show($@"{nameof(con1)} в состоянии:" +
                    $" {(s as SqlConnection).State}");
                };

            try
            {
                con1.Open(); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            finally
            {
                con1.Close();
            }
            #endregion

            #region Init MS Access

            #endregion
        }


        private void MenuItemAddClientClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteClientClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAddProductClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemDeleteProductClick(object sender, RoutedEventArgs e)
        {

        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
