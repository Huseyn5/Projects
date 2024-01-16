using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Interaction logic for OrderAccept.xaml
    /// </summary>
    public partial class OrderAccept : Window
    {
        public void Write(List<User> users)
        {
            XmlSerializer binaryFormatter = new XmlSerializer(typeof(List<User>));
            using (Stream stream = File.Create("users.txt"))
            {
                binaryFormatter.Serialize(stream, users);
            }
        }
        List<User> users = new List<User>();
        int i;
        List<Product> products = new List<Product>();
        public OrderAccept(List<User> _users, int _i, List<Product> _products)
        {
            InitializeComponent();
            users = _users;
            i = _i;
            products = _products;

            ClientNameDataBinding.DataContext = users[i].clients;
            ProductNameDataBinding.DataContext = products;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Quantity.Text != "" && DatePick.Text != "")
            {
                if (Convert.ToInt32(Quantity.Text) <= products[ProductNameDataBinding.SelectedIndex].Quantity)
                {
                    users[i].orders.Add(new Order(users[i].clients[ClientNameDataBinding.SelectedIndex].Name, products[ProductNameDataBinding.SelectedIndex].Name,
                        Convert.ToInt32(Quantity.Text), Convert.ToDateTime(DatePick.Text)));
                    products[ClientNameDataBinding.SelectedIndex].Quantity -= Convert.ToInt32(Quantity.Text);
                    Write(users);
                    WareHouse wareHouse = new WareHouse(users, i, products);
                    wareHouse.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Quantity of order cannot be more than quantity of the product at the ware house");
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled!");
            }
        }
    }
}
