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
    /// Interaction logic for ClientAdd.xaml
    /// </summary>
    public partial class ClientAdd : Window
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
        public ClientAdd(List<User> _users, int _i, List<Product> _products)
        {
            InitializeComponent();
            users = _users;
            i = _i;
            products = _products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text != "" && Surname.Text != "" && Email.Text != "" && PhoneNumber.Text != "" && Adress.Text != "")
            {
                users[i].clients.Add(new Client(Name.Text, Surname.Text, Email.Text, Convert.ToInt64(PhoneNumber.Text), Adress.Text));
                Write(users);
                WareHouse wareHouse = new WareHouse(users, i, products);
                wareHouse.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields must be filled!");

            }
        }
    }
}
