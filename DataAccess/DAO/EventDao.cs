using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace DataAccess.DAO
{
    public class EventDao : BaseDao
    {
        public EventDao() : base()
        {
            
        }
        
        #region Methods Get

        /// <summary>
        /// Get all events ordererd by date
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetAllEvents()
        {
            return this.context.Events.OrderBy(x => x.Date);
        }

        /// <summary>
        /// Get all published events ordered by date
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetAllPublishedEvent()
        {
            return context.Events.Where(e => e.IsPublished).OrderBy(e => e.Date);
        }

        /// <summary>
        /// Get all events preceding date if before is true
        /// else following the date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetEventByDate(DateTime date, bool before)
        {
            return before ? context.Events.Where(e => e.Date < date) : context.Events.Where(e => e.Date > date);
        }


        /// <summary>
        /// Get events by filter
        /// all filters are optional
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cp"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="creatorId"></param>
        /// <param name="seanceId"></param>
        /// <param name="movieId"></param>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetEventByFilter(string city = null, string cp = null, DateTime? startDate = null,
            DateTime? endDate = null, int? creatorId = null, int? seanceId = null, int? movieId = null,
            int? cinemaId = null)
        {
            var query = context.Events.Where(e => e.IsPublished);

            if (!string.IsNullOrEmpty(city))
                query = query.Where(e => e.Adress.City == city);

            if (!string.IsNullOrEmpty(cp))
                query = query.Where(e => e.Adress.PostalCode == cp);

            if (startDate.HasValue)
                query = query.Where(e => e.Date > startDate);

            if (endDate.HasValue)
                query = query.Where(e => e.Date < endDate);

            if (creatorId.HasValue)
                query = query.Where(e => e.Creator.Id == creatorId);

            if (seanceId.HasValue)
                query = query.Where(e => e.Seances.Any(s => s.SeanceId == seanceId));

            if (movieId.HasValue)
                query = query.Where(e => e.Seances.Any(s => s.Seance.Movie.Id == movieId));

            if (cinemaId.HasValue)
                query = query.Where(e => e.Seances.Any(s => s.Seance.Cinema.Id == cinemaId));

            query = query.OrderBy(e => e.Date);

            return query;
        }


        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetEventById(int id)
        {
            return context.Events.Find(id);
        }

        #endregion


        #region Methods Set

        /// <summary>
        /// Save event in database
        /// </summary>
        /// <param name="entity"></param>
        public void AddEvent(Event entity)
        {
            context.Events.Add(entity);
        }

        #endregion

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteEvent(Event entity)
        {
            context.Events.Remove(entity);
        }

        public void DeleteEvent(int id)
        {
            var entity = context.Events.Find(id);
            if(entity != null)
                context.Events.Remove(entity);
        }
    }
}