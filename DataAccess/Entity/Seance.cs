using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Seance
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        public decimal? Price { get; set; }
        
        public Movie Movie { get; set; }
        
        public Cinema Cinema { get; set; }
        
        public ICollection<SeanceEvent> Events { get; set; } 
        
        public ICollection<Vote> Votes { get; set; }

        public Seance()
        {
            this.Events = new HashSet<SeanceEvent>();
            this.Votes = new HashSet<Vote>();
        }
            
    }
}