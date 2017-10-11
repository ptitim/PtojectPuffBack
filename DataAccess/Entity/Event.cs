using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Entity
{
    public class Event
    {
        #region Properties
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(126)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Resume { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public int NbMaxOfParticipant { get; set; }

        public string RendezVousPoint { get; set; }

        public bool IsPublished { get; set; }

        #endregion


        #region  Properties Relational

        public Adress Adress { get; set; }

//        public int IdCreator { get; set; }
        public User Creator { get; set; }

        public ICollection<EventParticipants> Participants { get; set; }

        public ICollection<EventHosts> Hosts { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<SeanceEvent> Seances { get; set; }

        #endregion

        public Event()
        {
            this.Participants = new HashSet<EventParticipants>();
            this.Hosts = new HashSet<EventHosts>();
            this.Votes = new HashSet<Vote>();
            this.Seances = new HashSet<SeanceEvent>();
        }
    }
}