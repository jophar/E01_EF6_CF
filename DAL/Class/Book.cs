using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    class Book
    {
        internal int BookId { get; set; }

        [Required]
        [StringLength (100, ErrorMessage ="Max 100 chars.")]
        [MaxLength (100)]
        internal string BookTitle { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 chars.")]
        [MaxLength(100)]
        internal string BookAuthor { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Max 100 chars.")]
        [MaxLength(13)]
        internal string BookIsbn { get; set; }

        internal DateTime BookReleaseDate { get; set; }

        internal int BookPublisherId { get; set; }

        protected static void InsertBook(Book b)
        {
            int i = 0;

            Publisher p = new Publisher();

            using (var db = new BookContext())
            {
                p = db.Publisher.Select(x => x).Where(z => z.PublisherId == b.BookPublisherId).First();

                if (Publisher.ValidateExistingPublisher(p))
                {
                    db.Book.Add(b);
                    i = db.SaveChanges();
                }

                Utilities.ValidateIfInsertWasCorrect(i, "Book");
            }
        }
    }
}
