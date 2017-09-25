using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DataAccess.DAO;
using DataAccess.Entity;
using Newtonsoft.Json;
using Service.DTO;

namespace Service
{
    public class EventService
    {
        #region Properties

        private EventDao _eventDao;

        #endregion

        #region Ctor

        public EventService()
        {
            _eventDao = new EventDao();
        }

        #endregion


        #region Methods Get

        /// <summary>
        /// Get all events ordered by date
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<EventDto> GetAllEvents()
        {
            IEnumerable<Event> entities = new List<Event>();
            try
            {
                entities = _eventDao.GetAllEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            List<EventDto> dtos = entities.Select(EventDto.Extract).ToList();
            return dtos;
        }

        /// <summary>
        /// Get all published events, ordered by date
        /// </summary>
        /// <returns></returns>
        public List<EventDto> GetAllPublishedEvent()
        {
            IEnumerable<Event> entities = new List<Event>();
            try
            {
                entities = _eventDao.GetAllPublishedEvent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            List<EventDto> dtos = entities.Select(EventDto.Extract).ToList();
            return dtos;
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public EventDto GetEventById(int? id, out Treatment tr)
        {
            tr = new Treatment();

            if (!id.HasValue)
            {
                tr.AddFatalErrorWithCode(HttpStatusCode.BadRequest);
                return null;
            }
            
            var foundEvent = _eventDao.GetEventById(id.Value);
            if (foundEvent == null)
            {
                tr.AddErrorWithCode(HttpStatusCode.NotFound);
                return null;
            }
            
            var eventDto = EventDto.Extract(foundEvent);
            tr.AddObject(eventDto);
            
            return eventDto;
        }

        #endregion

        #region Methods Set
        
        /// <summary>
        /// Save event modification
        /// Create a new one if none is found
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public EventDto SaveEvent(EventDto dto, out Treatment tr)
        {
            tr = new Treatment();

            if (dto == null)
            {
                tr.AddErrorWithCode(HttpStatusCode.BadRequest);
                return null;
            }
            
             var evvent = _eventDao.GetEventById(dto.Id);
            
            var newEvent = EventDto.Populate(dto, evvent);
            
            // Check if event is new
            if(evvent == null)
                _eventDao.AddEvent(newEvent);
            
            _eventDao.SaveChanges();
            
            dto = EventDto.Extract(newEvent);

            return dto;
        }

//        public Event CreateEvent(string name, DateTime date,int? nbMax, bool isPublished )
//        {
//            var ev = new EventDto(name, date, nbMax, isPublished );
//
//            var newEvent = EventDto.Populate(ev);
//            
//            _eventDao.AddEvent(newEvent);
//
//            return newEvent;
//        }
        

        #endregion


    }
}