using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        [StringLength (100, ErrorMessage ="Max 100 chars.")]
        [MaxLength (100)]
        public string BookTitle { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 chars.")]
        [MaxLength(100)]
        public string BookAuthor { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Max 100 chars.")]
        [MaxLength(13)]
        public string BookIsbn { get; set; }

        public DateTime? BookReleaseDate { get; set; }

        public int BookPublisherID { get; set; }

        public static void InsertBook(Book b)
        {
            int i = 0;

            using (var db = new BookContext())
            {
                if (b.BookPublisherID != 0)
                {
                    db.Book.Add(b);
                    i = db.SaveChanges();
                }

                Utilities.ValidateIfInsertWasCorrect(i, "Book");
            }
        }
    }
}
