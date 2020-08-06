using System;
using System.Collections.Generic;
using System.Net.Http;
using northwind_api_client.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;

namespace northwind_api_client
{
    class Program
    {
        static Stopwatch s = new Stopwatch();

        static List<Customer> customers = new List<Customer>();

        static Customer newCustomer = new Customer() 
        { 
            CustomerId = "LEODW", 
            CompanyName = "Some Company", 
            ContactName = "Leo Hi", 
            ContactTitle = "Mr", 
            Address = "Piccadilly Road",
            City = "London",
            Region = "Lndn",
            PostalCode = "NWES23",
            Country = "UK",
            Phone = "0044-1231231",
            Fax = "0044-32132132"
        };
        static Customer customer = new Customer();

        static Uri url = new Uri("https://localhost:44320/api/Customers");

        static void Main(string[] args)
        {
            Thread.Sleep(5000);

            // Async Get All Customers
            Console.WriteLine("All customers");
            GetAllCustomers();
            Thread.Sleep(1000);

            // Async Get One Customer
            Console.WriteLine("\n\nOne Customer");
            GetOneCustomer("ALFKI");
            Thread.Sleep(1000);

            // Post a customer
            PostCustomerAsync(newCustomer);
        }

        static async void GetAllCustomers()
        {
            using(var httpClient = new HttpClient())
            {
                var data =  await httpClient.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);
            }

            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
            };
        }

        static async void GetOneCustomer(string customerId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{url}/{customerId}");
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            Console.WriteLine(customer.ContactName);
        }

        static async void PostCustomerAsync(Customer customer)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.PostAsync(url);
            }
        }
    }
}
