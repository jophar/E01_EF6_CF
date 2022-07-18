using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DAL.Utilities menu = new DAL.Utilities();

            try
            {
                DAL.Utilities.PrintMenus(menu._mainMenu);
                int menuChoice = Int32.Parse(Console.ReadLine());

                switch(menuChoice)
                {
                    case 1:
                        {
                            DAL.Publisher p = new DAL.Publisher();
                            p = DAL.Utilities.SavePublisherToObject();
                            DAL.Publisher.InsertPublisher(p);

                        } break;
                    case 2: 
                        {
                            DAL.Book b = new DAL.Book();
                            b = DAL.Utilities.SaveBookToObject();
                            DAL.Book.InsertBook(b);

                        } break;
                        
                    default: break;
                }
            }

            
            catch(Exception) { }

            Console.WriteLine("Exiting\n");
            Console.ReadKey();
        }
    }
}
