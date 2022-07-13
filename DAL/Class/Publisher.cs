using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    class Publisher
    {
        internal int PublisherId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 chars.")]
        [MaxLength(100)]
        internal string PublisherName { get; set; }

        protected static void InsertPublisher(Publisher p)
        {
            int i = 0;

            using(var db = new BookContext())
            {
                if (!ValidateExistingPublisher(p))
                {
                    db.Publisher.Add(p);
                    i = db.SaveChanges();
                }

                Utilities.ValidateIfInsertWasCorrect(i, "Publisher");
            } 
        }

        internal static bool ValidateExistingPublisher(Publisher p)
        {
            using (var db = new BookContext())
            {
                return db.Publisher.Select(a => a.PublisherName).Equals(p.PublisherName);
            }
        }
    }
}
