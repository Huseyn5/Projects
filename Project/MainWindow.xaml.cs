
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void Read(ref List<User> users)
        {
            XmlSerializer binaryFormatter = new XmlSerializer(typeof(List<User>));
            using (Stream stream = File.OpenRead("users.txt"))
            {
                users = (List<User>)binaryFormatter.Deserialize(stream);
            }
        }
        public void Read(ref List<Product> _products)
        {
            XmlSerializer binaryFormatter = new XmlSerializer(typeof(List<Product>));
            using (Stream stream = File.OpenRead("products.txt"))
            {
                _products = (List<Product>)binaryFormatter.Deserialize(stream);
            }
        }
        List<User> users = new List<User>();
        List<Product> products = new List<Product>();
        User user = new User();
        public MainWindow()
        {
            InitializeComponent();
            Read(ref users);
            Read(ref products);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Hide();
            Sign_up signUp = new(users, user);
            signUp.Show();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text != "" && PasswordBox.Text != "")
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (UsernameBox.Text == users[i].UserName)
                    {
                        if (PasswordBox.Text == users[i].Password)
                        {
                            user = users[i];
                            MessageBox.Show("Successful sign in!");
                            WareHouse wareHouse = new(users, i, products);
                            wareHouse.Show();
                            this.Close();

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("All fields must be entered!");
            }
        }
    }
}
