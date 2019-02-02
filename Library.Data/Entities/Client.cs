using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    [Table("Client")]
    public class Client
    {
        public Client()
        {
            Borrowers = new HashSet<Borrower>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        public bool IsBlocked { get; set; } = false;

        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public virtual ICollection<Borrower> Borrowers { get; set; }
    }
}