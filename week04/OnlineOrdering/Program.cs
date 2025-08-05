using System;
using System.Collections.Generic;

namespace OnlineOrderSystem
{
    // Class Address
    public class Address
    {
        private string _str; // Street address
        private string _cty; // City
        private string _sta; // State
        private string _cou; // Country

        public Address(string street, string city, string state, string country)
        {
            _str = street;
            _cty = city;
            _sta = state;
            _cou = country;
        }

        public bool IsInUSA()
        {
            return _cou.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFullAddress()
        {
            return $"{_str}\n{_cty}, {_sta}\n{_cou}";
        }

        // Properties
        public string Street => _str;
        public string City => _cty;
        public string State => _sta;
        public string Country => _cou;
    }

    // Class Customer
    public class Customer
    {
        private string _nam; // Customers name
        private Address _add; // Customers address

        public Customer(string name, Address address)
        {
            _nam = name;
            _add = address;
        }

        public bool IsInUSA()
        {
            return _add.IsInUSA();
        }

        // Propierties (getters)
        public string Name => _nam;
        public Address Address => _add;
    }

    // Class Product
    public class Product
    {
        private string _nam; // Product name
        private string _pid; // Product ID 
        private decimal _pri; // Unit price
        private int _qty;    // Count

        public Product(string name, string productId, decimal price, int quantity)
        {
            _nam = name;
            _pid = productId;
            _pri = price;
            _qty = quantity;
        }

        public decimal CalculateTotalPrice()
        {
            return _pri * _qty;
        }

        // Propierties (getters)
        public string Name => _nam;
        public string ProductId => _pid;
        public decimal Price => _pri;
        public int Quantity => _qty;
    }

    // Clase Order
    public class Order
    {
        private List<Product> _pro; // Product list
        private Customer _cus;     // Customers

        public Order(Customer customer)
        {
            _cus = customer;
            _pro = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _pro.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalProductsCost = 0;
            foreach (var product in _pro)
            {
                totalProductsCost += product.CalculateTotalPrice();
            }

            decimal shippingCost = _cus.IsInUSA() ? 5m : 35m;
            return totalProductsCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in _pro)
            {
                label += $"• {product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_cus.Name}\n{_cus.Address.GetFullAddress()}";
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Online Order System\n");

            // Create Addresses
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
            Address address3 = new Address("789 Oak Blvd", "Los Angeles", "CA", "USA");

            // Create customers
            Customer customer1 = new Customer("John Smith", address1);
            Customer customer2 = new Customer("Emma Johnson", address2);
            Customer customer3 = new Customer("Robert Brown", address3);

            // Create products
            Product product1 = new Product("Laptop", "P1001", 999.99m, 1);
            Product product2 = new Product("Wireless Mouse", "P1002", 24.99m, 2);
            Product product3 = new Product("Mechanical Keyboard", "P1003", 89.99m, 1);
            Product product4 = new Product("4K Monitor", "P1004", 299.99m, 1);
            Product product5 = new Product("Noise-Cancelling Headphones", "P1005", 199.99m, 1);
            Product product6 = new Product("USB-C Cable", "P1006", 9.99m, 3);

            // Create orders and add products
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product6);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            Order order3 = new Order(customer3);
            order3.AddProduct(product5);
            order3.AddProduct(product2);
            order3.AddProduct(product6);

            // Display order information
            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
            DisplayOrderDetails(order3);
        }

        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("\n" + order.GetPackingLabel());
            Console.WriteLine($"Total Order Cost: ${order.CalculateTotalCost():0.00}");
            Console.WriteLine("=========================================================\n");
        }
    }
}
