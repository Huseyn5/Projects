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
    /// Interaction logic for ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window
    {
        public void Write(List<Product> _products)
        {
            XmlSerializer binaryFormatter = new XmlSerializer(typeof(List<Product>));
            using (Stream stream = File.Create("products.txt"))
            {
                binaryFormatter.Serialize(stream, _products);
            }
        }
        List<User> users = new List<User>();
        int i;
        List<Product> products = new List<Product>();
        public ProductAdd(List<User> _users, int _i, List<Product> _products)
        {
            InitializeComponent();
            users = _users;
            i = _i;
            products = _products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            if(NameBox.Text != "" && PriceBox.Text != "" && QuantityBox.Text != "" && DescriptionBox.Text != "")
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if(NameBox.Text == products[i].Name)
                    {
                        check = false;
                        products[i].Price = Convert.ToDouble(PriceBox.Text);
                        products[i].Quantity += Convert.ToInt32(QuantityBox.Text);
                        Write(products);
                        WareHouse wareHouse = new WareHouse(users, i, products);
                        wareHouse.Show();
                        this.Close();
                    }
                }
                if (check)
                {
                    products.Add(new Product(NameBox.Text, Convert.ToDouble(PriceBox.Text),
                        Convert.ToInt32(QuantityBox.Text), DescriptionBox.Text));
                    Write(products);
                    WareHouse wareHouse1 = new WareHouse(users, i, products);
                    wareHouse1.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled!");
            }
        }
    }
}
