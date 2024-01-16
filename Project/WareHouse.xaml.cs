using System;
using System.Collections.Generic;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for WareHouse.xaml
    /// </summary>
    public partial class WareHouse : Window
    {
        class MyClass
        {
            public string UserName { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public DateTime ArrivalDate { get; set; }
        }
        List<User> users = new List<User>();
        int i;
        List<Product> products = new List<Product>();
        public WareHouse(List<User> _users, int _i, List<Product> _products)
        {
            InitializeComponent();
            users = _users;
            i = _i;
            products = _products;
            ClientDataBinding.ItemsSource = users[i].clients;
            OrderDataBinding.ItemsSource = users[i].orders;
            ProductDataBinding.ItemsSource = products;
        }

        private void ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientAdd clientAdd = new ClientAdd(users, i, products);
            clientAdd.Show();
            this.Close();
        }

        private void OrderAccept_Click(object sender, RoutedEventArgs e)
        {
            OrderAccept orderAccept = new OrderAccept(users, i, products);
            orderAccept.Show();
            this.Close();
        }
        private void ProductAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd productAdd = new ProductAdd(users, i, products);
            productAdd.Show();
            this.Close();
        }

        private void ClientList_Click(object sender, RoutedEventArgs e)
        {
            ClientDataBinding.Visibility = Visibility.Visible;
            OrderDataBinding.Visibility = Visibility.Collapsed;
            ProductDataBinding.Visibility = Visibility.Collapsed;
        }

        private void OrderList_Click(object sender, RoutedEventArgs e)
        {
            ClientDataBinding.Visibility = Visibility.Collapsed;
            OrderDataBinding.Visibility = Visibility.Visible;
            ProductDataBinding.Visibility = Visibility.Collapsed;
        }

        private void ProductList_Click(object sender, RoutedEventArgs e)
        {
            ClientDataBinding.Visibility = Visibility.Collapsed;
            OrderDataBinding.Visibility = Visibility.Collapsed;
            ProductDataBinding.Visibility = Visibility.Visible;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterBox_TextChanaged(object sender, TextChangedEventArgs e)
        {
            List<Order> myorders = new List<Order>();
            List<MyClass> myClasses = new List<MyClass>();
            for (int j = 0; j < users[i].orders.Count; j++)
            {
                if ((users[i].orders[j].Name.Contains(FilterBox.Text)) ||
                    users[i].orders[j].Product.Contains(FilterBox.Text))
                {
                    myorders.Add(users[i].orders[j]);
                }
            }
            OrderDataBinding.ItemsSource = myorders;


        }
    }
}
