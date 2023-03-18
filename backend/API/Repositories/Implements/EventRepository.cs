using API.Repositories.Interfaces;
using Data;
using Data.Entities;

namespace API.Repositories.Implements
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
