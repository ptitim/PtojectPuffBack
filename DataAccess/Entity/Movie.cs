
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        
        [MaxLength(126)]
        public string Real { get; set; }
        
        public string Actors { get; set; }
        
        public string Synopsis { get; set; }
            
        public int PG { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public TimeSpan TimeLength { get; set; }
        
        public ICollection<MovieCategory> Categories { get; set; }
        
        public ICollection<Seance> Seances { get; set; }

        public Movie()
        {
            this.Categories = new HashSet<MovieCategory>();
            this.Seances = new HashSet<Seance>();
        }
    }
}