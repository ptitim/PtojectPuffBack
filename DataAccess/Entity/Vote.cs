using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Vote
    {
        [Key]
        public int EventId { get; set; }
        public Event Event { get; set; }
        
        public int SeanceId { get; set; }
        public Seance Seance { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}