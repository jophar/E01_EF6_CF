using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Migrations_Books_DAL
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }

        // 1 author - n books
        public ICollection<Book> Book { get; set; }
    }
}
