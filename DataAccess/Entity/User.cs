using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class User
    {
        [Key]
        public int Id { get; protected set; }
        
        [MaxLength(126)]
        public string Lastname { get; set; }
        
        [MaxLength(126)]
        public string Firstname { get; set; }
        
        [Required]
        [MaxLength(126)]
        public string Pseudo { get; set; }
        
        [Required]
        [MaxLength(126)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Salt { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Roles { get; set;  }
        
        public bool RemenberMe { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public InfoUser InfoUser { get; set; }
        
        public ICollection<Event> CreatedEvents { get; set; }
        
        public ICollection<EventParticipants> ParticpationEvents { get; set; }
        
        public ICollection<EventHosts> HostEvents { get; set; }
        
        public ICollection<Vote> Votes { get; set; }

        public User()
        {
            ParticpationEvents = new HashSet<EventParticipants>();
            HostEvents = new HashSet<EventHosts>();
            CreatedEvents = new HashSet<Event>();
            Votes = new HashSet<Vote>();
        }
    }
}