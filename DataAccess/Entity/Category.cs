using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(126)]
        public string Name { get; set; }
        
        public ICollection<MovieCategory> Movies { get; set; }

        public Category()
        {
              Movies = new HashSet<MovieCategory>();
        }
    }
}