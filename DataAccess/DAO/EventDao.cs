using System.Collections.Generic;
using System.Linq;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class EventDao : BaseDao
    {

        public EventDao() : base()
        {
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns></returns>
        public IQueryable<Event> GetAllEvents()
        {
            return this.context.Events.OrderBy(x => x.Date);
//            return this.Events.OrderBy(x => x.Date);
        }

        public Event GetEventById(int id)
        {
            return context.Events.Find(id);
        }
        
        public void DeleteEvent(Event entity)
        {
            context.Events.Remove(entity);
        }
    }
}