using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Publisher
    {
        public int PublisherID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max 100 chars.")]
        [MaxLength(100)]
        public string PublisherName { get; set; }

        public static void InsertPublisher(Publisher p)
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
                return db.Publisher.Select(a => a).Where(b => b.PublisherName.Equals(p.PublisherName)).Any();
            }
        }
    }
}
