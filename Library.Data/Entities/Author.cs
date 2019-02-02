using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entities
{
    [Table("Author")]
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("Gender")]
        public int  GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
