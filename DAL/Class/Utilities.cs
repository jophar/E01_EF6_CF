using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Utilities
    {
        public List<string> _mainMenu = new List<string>()
        {
            "** BOOK'S DB *************\n",
            "1) Add a Publisher\n",
            "2) Add a Book\n"
        };
        public static Publisher SavePublisherToObject()
        {
            Publisher p = new Publisher();
            Console.Write("Insert publisher's name: ");
            p.PublisherName = Console.ReadLine();

            return p;
        }

        public static void PrintMenus(List<string> l)
        {
            foreach (string menu in l)
            { 
                Console.Write(menu);
            }
        }
        public static Book SaveBookToObject()
        {
            Book book = new Book();

            Console.Write("Insert book's title: ");
            book.BookTitle = Console.ReadLine();
            Console.Write("Insert book's author: ");
            book.BookAuthor = Console.ReadLine();
            Console.Write("Insert book's ISBN: ");
            book.BookIsbn = Console.ReadLine();
            Console.Write("Insert book's year release date: ");
            int y = Int32.Parse(Console.ReadLine());
            Console.Write("Insert book's month release date: ");
            int m = Int32.Parse(Console.ReadLine());

            if(y > 0 && m > 0)
                book.BookReleaseDate = new DateTime(y, m, 1);
            else
                book.BookReleaseDate = null;

            Console.Write("Insert book's publisher name: ");
            string pName = Console.ReadLine();
            book.BookPublisherID = GetPublisherIdByName(pName);

            return book;
        }

        internal static void ValidateIfInsertWasCorrect(int i, string type)
        {
            var test = i != 0 ? $"{type} was inserted in database" : $"There was an error inserting the {type} into the database\n";
            Console.WriteLine(test);
        }
        
        internal static int GetPublisherIdByName(string name)
        {
            using(var db = new BookContext())
            {
                if (db.Publisher.Any(c => c.PublisherName.Equals(name)))
                    return db.Publisher.First(c => c.PublisherName.Equals(name)).PublisherID;
                else
                    return 0;
            }
        }
    }
}
