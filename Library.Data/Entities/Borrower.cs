using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entities
{
    [Table("Borrower")]
    public class Borrower
    {
        [Key]
        public int Id { get; set; }
        public DateTime TakenDate { get; set; } = DateTime.Now;
        public DateTime ExpectedReturnDate { get; set; } = DateTime.Now.AddDays(3);
        public DateTime ActualReturnDate { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}
