﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DocghifileXML
{
    class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }
    class ReadWriteFileXML
    {
        public static bool WriteToFile()
        {
            Book book = new Book();
            book.Title = "Dac Nhan Tam";
            book.Price = 123.5f;
            try
            {
                XDocument xDoc = XDocument.Load(@"C:\File & Serialization\DocghifileXML\DocghifileXML\books.xml");
                XElement newBook = new XElement("book",
                new XElement("title", book.Title),
                new XElement("price", book.Price.ToString()));

                xDoc.Element("bookstore").Add(newBook);
                xDoc.Save(@"C:\File & Serialization\DocghifileXML\DocghifileXML\books.xml");
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return false;
            }
        }
        static void ReadFromFile()
        {
            XmlTextReader reader = new XmlTextReader(@"C:\File & Serialization\DocghifileXML\DocghifileXML\books.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            bool isWriten = WriteToFile();
            if (isWriten)
            {
                ReadFromFile();
            }
            else
            {
                System.Console.WriteLine("Write data to file occur an error. Please try again !");
            }

        }

    }
}
