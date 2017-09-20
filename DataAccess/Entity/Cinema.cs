using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        
        [MaxLength(256)]
        public string Company { get; set; }
        
        public Adress Adress { get; set; }
        
        public ICollection<Seance> Seances { get; set; }

        public Cinema()
        {
             Seances = new HashSet<Seance>();
        }
    }
}