using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Client> clients { get; set; } = new List<Client>();
        public List<Order> orders { get; set; } = new List<Order>();

        public User() { }
        public User(string name, string lastname, string username, string password)
        {
            Name = name;
            LastName = lastname;
            UserName = username;
            Password = password;
        }
    }
    
    public class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email {get; set; }
        public long PhoneNumber { get; set; }
        public string Adress {get; set; }

        public Client() { }
        public Client(string name, string lastname, string email, long phonenumber, string adress)
        {
            this.Name = name;
            this.LastName = lastname;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.Adress = adress;
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Order() { }
        public Order(string name, string product, int quantity, DateTime arrivaldate)
        {
            this.Name = name;
            this.Product = product;
            this.Quantity = quantity;
            this.ArrivalDate = arrivaldate;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Product() { }
        public Product(string name, double price, int quantity, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Description = description;
        }
    }


    //public class Person
    //{
    //    private static int id = 1;
    //    private string name;
    //    private int age;
    //    private float salary;
    //    public static int next_id() { return id++; }
    //    public string getName() { return name; }
    //    public void setName(string _name) { this.name = _name; }
    //}
}
