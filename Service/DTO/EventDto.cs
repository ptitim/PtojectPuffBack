using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entity;

namespace Service.DTO
{
    public class EventDto
    {
        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Resume { get; set; }

        public int NumberMaxOfParticipant { get; set; }

        public string RendezVousPoint { get; set; }

        public bool IsPublished { get; set; }

        public int IdCreator { get; set; }

        public List<SeanceDto> Seance { get; set; }

        #endregion

        #region Ctor

        public EventDto()
        {
        }

        public EventDto(string name, DateTime date, int? nbMaxParticipant, bool isPublished)
        {
            Name = name;
            Date = date;
            NumberMaxOfParticipant = nbMaxParticipant ?? 0;
            IsPublished = isPublished;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Extract event entity into event Dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EventDto Extract(Event entity)
        {
            var dto = new EventDto();

            if (entity == null) return dto;

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Date = entity.Date;
            dto.IsPublished = entity.IsPublished;
            dto.Description = entity.Description;
            dto.Resume = entity.Resume;

            dto.NumberMaxOfParticipant = entity.NbMaxOfParticipant;
            dto.RendezVousPoint = entity.RendezVousPoint;
            dto.IdCreator = entity.IdCreator;

            dto.Seance = SeanceDto.Extract(entity.Seances);

            return dto;
        }

        public static Event Populate(EventDto dto, Event entity = null, int? creatorId = null)
        {
            if (entity == null)
                entity = new Event();

            entity.Name = dto.Name;
            entity.Date = dto.Date;
            entity.Description = dto.Description;
            entity.NbMaxOfParticipant = dto.NumberMaxOfParticipant;
            entity.Resume = dto.Resume;
            entity.RendezVousPoint = dto.RendezVousPoint;

            if (dto.Seance != null && dto.Seance.Any())
            {
                foreach (var seanceDto in dto.Seance)
                {
                    var tmp = entity.Seances.FirstOrDefault(se => se.SeanceId == seanceDto.Id);
                    if (tmp != null)
                    {
                        tmp.Seance = SeanceDto.Populate(seanceDto, tmp.Seance);
                    }
                    else
                    {
                        tmp = new SeanceEvent() {EventId = dto.Id, Seance = SeanceDto.Populate(seanceDto)};
                    }
                }
            }
            if (creatorId != null)
                entity.IdCreator = creatorId.Value;

            return entity;
        }

        #endregion
    }
}