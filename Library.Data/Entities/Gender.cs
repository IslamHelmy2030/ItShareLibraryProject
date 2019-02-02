using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entities
{
    [Table("Gender")]
    public class Gender
    {
        public Gender()
        {
            Authors = new HashSet<Author>();
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }
        
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
