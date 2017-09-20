using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Street { get; set; }

        [MaxLength(10)]
        public int Number { get; set; }
        
        [MaxLength(256)]
        public string PostalCode { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Country { get; set; }
        
        [MaxLength(256)]
        public string City { get; set; }
        
    }
}