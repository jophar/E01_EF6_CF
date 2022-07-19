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

        [Required]
        [StringLength(9, ErrorMessage = "9 character limit.")]
        [MaxLength(9)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public int DdcID { get; set; } // Dewey Decimal Classification
        #endregion

        #region Navigation properties 
        // 1 book - n publishers 
        public Publisher Publisher { get; set; }
        public DeweyDecimalClassification Ddc { get; set; }

        #endregion
    }
}
