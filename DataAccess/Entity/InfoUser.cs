using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class InfoUser
    {
        [Key]
        [ForeignKey("Id")]
        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public string Description { get; set; }
    }
}