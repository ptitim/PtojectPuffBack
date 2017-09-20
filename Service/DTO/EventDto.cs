using System;

namespace Service.DTO
{
    public class EventDto
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Resume { get; set; }
        
        public int NumberMaxOfParticipant { get; set; }
        
        public string RendezVousPoint { get; set; }
        
        public bool IsPublished { get; set; }
        
    }
}