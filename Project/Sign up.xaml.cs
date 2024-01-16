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
    /// Interaction logic for Sign_up.xaml
    /// </summary>
    public partial class Sign_up : Window
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
        User user = new User();
        public Sign_up(List<User> _users, User _user)
        {
            InitializeComponent();
            users = _users;
            user = _user;
        }

        private void Password_Show(object sender, RoutedEventArgs e)
        {
            if (Password.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Text = Password.Password;
                Password.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                Password.Password = PasswordTextBox.Text;
                PasswordTextBox.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Visible; 
            }
        }

        private void RePassword_Show(object sender, RoutedEventArgs e)
        {
            if (RePassword.Visibility == Visibility.Visible)
            {
                RePasswordTextBox.Text = RePassword.Password;
                RePassword.Visibility = Visibility.Collapsed;
                RePasswordTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                RePassword.Password = RePasswordTextBox.Text;
                RePasswordTextBox.Visibility = Visibility.Collapsed;
                RePassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(UserNameBox.Text != "" && Password.Password != "" && RePassword.Password != "" && NameBox.Text != "" 
                && SurnameBox.Text != "")
            {
                if (Password.Password == RePassword.Password)
                {
                    
                    user = new User( NameBox.Text, SurnameBox.Text, UserNameBox.Text, Password.Password);
                    users.Add(user);
                    Write(users);
                    App.Current.MainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("RePassword is not the same as Password!");
                }
            }
            else
            {
                MessageBox.Show("All fields must be completed!");
            }
        }
    }
}
