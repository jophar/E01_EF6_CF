using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Migrations_Books_DAL
{
    public class Book
    {
        #region Scalar properties 
        public int BookID { get; set; }

        // Foreign key, without data annotation, just using code conventions 
        public int PublisherID { get; set; }
        public int DeweyID { get; set; } // Dewey Decimal Classification

        [Required]
        [StringLength(9, ErrorMessage = "9 character limit.")]
        [MaxLength(9)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public string Titulo { get; set; }
       
        #endregion

        #region Navigation properties 
        // 1 book - 1 publisher 
        public Publisher Publisher { get; set; }
        // 1 book - 1 classification
        public DeweyDecimalClassification DeweyDecimalClassification { get; set; }
        // 1 book - n authors
        public ICollection<Author> Author { get; set; }
        #endregion
    }
}
