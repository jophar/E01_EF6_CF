using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Migrations_Books_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BooksDBClient.CreatePublisher();
            BooksDBClient.CreateBook();
            Console.Write("Data entered successfully.");
            Console.ReadKey();
        }
    }
}
