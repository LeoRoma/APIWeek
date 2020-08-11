using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using lab_33b_xml_serialise.Models;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace lab_33b_xml_serialise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read some Northwind products
            List<Product> products = new List<Product>();

            using (var db = new NorthwindContext())
            {
                products = db.Products.Take(5).ToList();
                //Skip(5).Take(5) Same way of Pagination
            }
            products.ForEach(product => Console.WriteLine($"product Id {product.ProductId,-10} Name {product.ProductName}"));

            // Imagine someone created this xml file in brazil and emailed it to us
            var xmlProducts = new XElement(
                "Products",
                    from p in products
                    select new XElement ("Product", 
                        new XElement("ProductId", p.ProductId),
                        new XElement("ProductName", p.ProductName),
                        new XElement("UnitPrice", p.UnitPrice)
                )
            );

            //Save document
            var xmlProductsDocument = new XDocument(xmlProducts);
            xmlProductsDocument.Save("Products.xml");
            //print
            Console.WriteLine(xmlProductsDocument);

            // Assume data being sent to us over the internet - it can be very large so 
            // safest to "Stream" data from internet

            var xmlProductsList = new Products();

            using (var reader = new StreamReader("Products.xml"))
            {
                // Deserialise from xml to Northwind Products
                var serializer = new XmlSerializer(typeof(Products));
                xmlProductsList = (Products)serializer.Deserialize(reader);
            }
            Console.WriteLine("\n\nProducts Deserialised");
            xmlProductsList.ProductsList.ForEach(p => Console.WriteLine($"{p.ProductId, -5} {p.ProductName, -40} {p.UnitPrice}"));
        }
    }

    [Serializable, XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductsList { get; set; }
    }
}
