using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DAO;
using DataAccess.Entity;
using Service.DTO;

namespace Service
{
    public class EventService
    {

        private EventDao _eventDao;

        public EventService()
        {
            _eventDao = new EventDao();
        }
        
        public List<EventDto> GetAllEvents()
        {
            IEnumerable<Event> entities;
            try
            {
                entities = _eventDao.GetAllEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

            List<EventDto> dtos = entities.Select(Extract).ToList();
            return dtos;
        }


        /// <summary>
        /// Extract event entity into event Dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EventDto Extract(Event entity)
        {
            var dto = new EventDto();

            if (entity == null) return dto;
            
            dto.Name = entity.Name;
            dto.Date = entity.Date;
            dto.Description = entity.Description;
            dto.NumberMaxOfParticipant = entity.NbMaxOfParticipant;

            return dto;
        }
    }
}