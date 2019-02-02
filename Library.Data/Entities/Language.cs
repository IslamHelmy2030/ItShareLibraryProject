using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    [Table("Language")]
    public class Language
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string WrittenLanguage { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}