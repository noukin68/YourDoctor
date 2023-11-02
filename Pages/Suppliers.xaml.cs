using YourDoctor.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace YourDoctor
{
    /// <summary>
    /// Логика взаимодействия для Deliv.xaml
    /// </summary>
    public partial class Suppliers : Page
    {

        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["yourDoctor"].ConnectionString);
        SqlDataAdapter adapter;
        DataTable dt;

        public Suppliers()
        {
            InitializeComponent();
            con.Open();

            // Создайте SQL-запрос для выборки данных
            string query = "SELECT SupplierID, Name, ContactName, Phone FROM Suppliers";
            MySqlCommand cmd = new MySqlCommand(query, con);

            // Используйте MySqlDataAdapter для работы с данными
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

            // Создайте DataTable и заполните его данными из MySQL
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Привяжите DataTable к элементу управления WPF (например, DataGrid)
            gridMe.ItemsSource = dt.DefaultView;

            // Закройте подключение после использования
            con.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dt);
            MessageBox.Show("Данные успешно обновлены!");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEditableCollectionView iecv = CollectionViewSource.GetDefaultView(gridMe.ItemsSource) as IEditableCollectionView;

                while (gridMe.SelectedIndex >= 0)
                {
                    int selectedIndex = gridMe.SelectedIndex;
                    DataGridRow dgr = gridMe.ItemContainerGenerator.ContainerFromIndex(selectedIndex) as DataGridRow;
                    dgr.IsSelected = false;

                    if (iecv.IsEditingItem)
                    {
                        iecv.CommitEdit();
                        iecv.RemoveAt(selectedIndex);
                        adapter.Update(dt);
                    }
                    else
                    {
                        iecv.RemoveAt(selectedIndex);
                        adapter.Update(dt);
                    }
                }
                MessageBox.Show("Данные успешно удалены!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
