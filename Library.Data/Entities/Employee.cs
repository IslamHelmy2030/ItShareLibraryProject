using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {
            Employees = new HashSet<Employee>();
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
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
