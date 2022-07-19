using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Migrations_Books_DAL
{
    public class DeweyDecimalClassification
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int DeweyID { get; set; }
        public string DdcCode { get; set; }
        public string DDC { get; set; }

        // Navigation Property
        public ICollection<Book> Book { get; set; }
    }
}
