using YourDoctor.Pages;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace YourDoctor
{
    /// <summary>
    /// Логика взаимодействия для Delivery.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdProducts_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Pages.Products());
        }

        private void rdCustomers_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Customers());
        }

        private void rdOrders_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Orders());
        }

        private void rdOrderItems_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new OrderItems());
        }

        private void rdSuppliers_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Suppliers());
        }

        private void rdSupply_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Supply());
        }

        private void rdPrescriptionMedications_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new PrescriptionMedications());
        }

        private void rdReviews_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Reviews());
        }
    }
}
