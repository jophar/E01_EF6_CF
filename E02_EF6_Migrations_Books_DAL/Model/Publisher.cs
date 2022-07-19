using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Migrations_Books_DAL
{
    public class Publisher
    {
        public int PublisherID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public string Name { get; set; }

        #region Navigation properties         
        // 1 publisher - n books 
        public ICollection<Book> Book { get; set; }
        #endregion


    }
}
