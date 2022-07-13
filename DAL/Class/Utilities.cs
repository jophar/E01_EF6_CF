using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Utilities
    {
        internal List<string> _mainMenu = new List<string>()
        {

        };
        internal static Publisher SavePublisherToObject()
        {
            Publisher p = new Publisher();
            Console.Write("Insert publisher's name: ");
            p.PublisherName = Console.ReadLine();

            return p;
        }

        internal static Book SaveBookToObject()
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
            book.BookReleaseDate = new DateTime(y, m, 1);
            Console.Write("Insert book's publisher name: ");
            string pName = Console.ReadLine();
            book.BookPublisherId = GetPublisherIdByName(pName);

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
                Publisher temp = new Publisher();
                temp = db.Publisher.Select(p => p).Where(p => p.PublisherName.Equals(name)).First();
                return temp.PublisherId;
            }
        }
    }
}
