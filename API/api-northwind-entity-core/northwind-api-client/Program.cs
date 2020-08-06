using System;
using System.Collections.Generic;
using System.Net.Http;
using northwind_api_client.Models;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace northwind_api_client
{
    class Program
    {
        static Stopwatch s = new Stopwatch();

        static List<Customer> customers = new List<Customer>();

        static Customer newCustomer = new Customer() 
        { 
            CustomerId = "NEW03", 
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
            Thread.Sleep(2000);


            // Async Get All Customers
            Console.WriteLine("All customers");
            GetAllCustomersAsync();
            Thread.Sleep(2000);
            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
            };

            // Async Get One Customer
            Console.WriteLine("\n\nOne Customer");
            GetOneCustomerAsync("ALFKI");
            Thread.Sleep(2000);

            // Update

            // Delete (async)
            DeleteCustomerAsync("NEWCU");
            Thread.Sleep(2000);

            // Delete (async return a Task)
            //DeleteCustomerAsyncTask("NEW02").Wait();
            //Thread.Sleep(1000);
        }

        static async void GetAllCustomersAsync()
        {
            
            using(var httpClient = new HttpClient())
            {
                var data =  await httpClient.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
        }

        static void GetAllCustomers()
        {

            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data.Result);
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


        static bool CustomerExists(string customerId)
        {
            GetAllCustomers();
            customer = null;
            customer = customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        static async void PostCustomerAsync(Customer newCustomer)
        {
            // Check customer does not exist
            if (!CustomerExists(newCustomer.CustomerId))
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
            if (CustomerExists(customerId) == true)
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
                Console.WriteLine($"A customer with ID: {customerId} doesn't exists");
            }
        }

        //static async Task<HttpResponseMessage> DeleteCustomerAsyncTask(string customerId)
        //{
        //    if (!CustomerExists(newCustomer.CustomerId))
        //    {
        //        // Send Data
        //        using (var httpClient = new HttpClient())
        //        {
        //            var httpResponse = await httpClient.DeleteAsync($"{url}/{customerId}");
        //            if (httpResponse.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine($"Record {customerId} successfully deleted");
        //            }
        //            return httpResponse;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"A customer with ID: {newCustomer.CustomerId} doesn't exists");
        //        return null;
        //    }
        //}
    }
}
