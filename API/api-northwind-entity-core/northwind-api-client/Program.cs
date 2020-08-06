using System;
using System.Collections.Generic;
using System.Net.Http;
using northwind_api_client.Models;
using System.Linq;
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
            CustomerId = "NEW02", 
            CompanyName = "Some Company", 
            ContactName = "Leo Hello", 
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

            // Post a customer
            PostCustomerAsync(newCustomer);
            Thread.Sleep(1000);


            // Async Get All Customers
            Console.WriteLine("All customers");
            GetAllCustomersAsync();
            Thread.Sleep(1000);
            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
            };

            // Async Get One Customer
            Console.WriteLine("\n\nOne Customer");
            GetOneCustomerAsync("NEWCU");
            Thread.Sleep(1000);

            // Update

            // Delete
            DeleteCustomerAsync("NEW02");
            Thread.Sleep(1000);
        }

        static async void GetAllCustomersAsync()
        {
            
            using(var httpClient = new HttpClient())
            {
                var data =  await httpClient.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
        }

        static async void GetOneCustomerAsync(string customerId)
        {
            using (var httpClient = new HttpClient())
            {
                var data = await httpClient.GetStringAsync($"{url}/{customerId}");
                customer = JsonConvert.DeserializeObject<Customer>(data);
            }
            Console.WriteLine(customer.ContactName);
        }

        static void GetOneCustomer(string customerId)
        {
            customer = null;
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync($"{url}/{customerId}");
                customer = JsonConvert.DeserializeObject<Customer>(data.Result);
            }
            Console.WriteLine(customer.ContactName);
        }

        //static bool CheckCustomerExists(string customerId)
        //{
        //    var customerExists = customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
        //    if(customerExists != null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        static async void PostCustomerAsync(Customer newCustomer)
        {
            // Check customer does not exist
            GetOneCustomer(newCustomer.CustomerId);
            if (customer == null)
            {
                // Firstly serialise our customer to JSON
                string newCustomerAsJson = JsonConvert.SerializeObject(newCustomer, Formatting.Indented);

                // Convert this to HTTP
                var httpContent = new StringContent(newCustomerAsJson);

                // Add headers before send
                httpContent.Headers.ContentType.MediaType = "application/json";
                httpContent.Headers.ContentType.CharSet = "UTF-8";

                // Send Data
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.PostAsync(url, httpContent);
                    if(httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {newCustomer.CustomerId} successfully added");
                    }
                
                }
            }
            else
            {
                Console.WriteLine($"A customer with ID: {newCustomer.CustomerId} already exists");
            }
        }

        static async void DeleteCustomerAsync(string customerId)
        {
            GetOneCustomer(customerId);
            if (customer != null)
            {
                // Send Data
                using (var httpClient = new HttpClient())
                {
                    var httpResponse = await httpClient.DeleteAsync($"{url}/{customerId}");
                    if(httpResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Record {customerId} successfully deleted");
                    }
                }
            }
            else
            {
                Console.WriteLine($"A customer with ID: {newCustomer.CustomerId} doesn't exists");
            }
        }


    }
}
