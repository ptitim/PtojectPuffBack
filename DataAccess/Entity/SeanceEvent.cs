namespace DataAccess.Entity
{

    public class SeanceEvent
    {
        public int SeanceId { get; set; }
        public Seance Seance { get; set; }
        
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}