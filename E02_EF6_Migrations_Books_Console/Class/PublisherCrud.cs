using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E02_EF6_Migrations_Books_DAL;

namespace E02_EF6_Migrations_Books_Console
{
    public class PublisherCrud
    {
        public static void CreatePublisher()
        {
            for (int i = 1; i <= 4; i++)
                {
                    var publisher = new Publisher
                    {
                        Name = $"New publisher {i}"
                    };

                    using (var context = new BookDBContext())
                    {
                        context.Publisher.Add(publisher);
                        context.SaveChanges();
                    }
                }
        }
        public static void ReadPublisher() // Reads all publishers
        {
            using (var context = new BookDBContext())
            {
                var publisherList = context.Publisher.Select(p => p);

                foreach (var item in publisherList)
                {
                    Console.WriteLine($"{item.PublisherID} - {item.Name}\n");
                }
            }
        }
        public static void UpdatePublisher()
        {
            using (var context = new BookDBContext())
            {
                var r = context.Publisher.SingleOrDefault(p => p.PublisherID.Equals(2));

                r.Name = "Updated Publisher";
                context.SaveChanges();
            }
        }
        public static void DeletePublisher()
        {
            using (var context = new BookDBContext())
            {
                var r = context.Publisher.SingleOrDefault(p => p.PublisherID.Equals(3));

                context.Publisher.Remove(r);
                context.SaveChanges();
            }
        }

    }
}
