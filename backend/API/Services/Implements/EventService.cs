using API.DTOs.Event.CreateEvent;
using API.DTOs.Event.GetEvent;
using API.DTOs.Event.UpdateEvent;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Data.Entities;

namespace API.Services.Implements
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository EventRepository)
        {
            _eventRepository = EventRepository;
        }

        public async Task<CreateEventResponse?> CreateEventAsync(CreateEventRequest request)
        {
            using (var transaction = _eventRepository.DatabaseTransaction())
            {
                try
                {
                    var newEntity = new Event
                    {
                        EventName = request.EventName,
                        EventDescription = request.EventDescription,
                        FirstClosingDate = request.FirstClosingDate,
                        LastClosingDate = request.LastClosingDate
                    };

                    var newEvent = _eventRepository.Create(newEntity);

                    _eventRepository.SaveChanges();

                    transaction.Commit();

                    return new CreateEventResponse()
                    {
                        Id= newEvent.Id,
                        EventName = newEvent.EventName,
                        EventDescription = newEvent.EventDescription,
                        FirstClosingDate = newEvent.FirstClosingDate.ToString("dd/MM/yyyy"),
                        LastClosingDate = newEvent.LastClosingDate.ToString("dd/MM/yyyy")
                    };
                }
                catch
                {
                    transaction.Rollback();

                    return null;
                }
            }
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            using (var transaction = _eventRepository.DatabaseTransaction())
            {
                try
                {
                    var entity = await _eventRepository.GetAsync(entity => entity.Id == id);

                    if (entity != null)
                    {
                        _eventRepository.Delete(entity);

                        _eventRepository.SaveChanges();

                        transaction.Commit();
                    }
                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public async Task<IEnumerable<GetEventResponse>> GetAllAsync()
        {
            return (await _eventRepository.GetAllAsync())
                .Select(entity => new GetEventResponse
                {
                    Id = entity.Id,
                    EventName = entity.EventName,
                    EventDescription = entity.EventDescription,
                    FirstClosingDate = entity.FirstClosingDate.ToString("dd/MM/yyyy"),
                    LastClosingDate= entity.LastClosingDate.ToString("dd/MM/yyyy"),
                });
        }

        public async Task<GetEventResponse?> GetByIdAsync(int id)
        {
            var entity = await _eventRepository.GetAsync(entity => entity.Id == id);

            if (entity == null) { return null; }

            return new GetEventResponse
            {
                Id = entity.Id,
                EventName = entity.EventName,
                EventDescription = entity.EventDescription,
                FirstClosingDate = entity.FirstClosingDate.ToString("dd/MM/yyyy"),
                LastClosingDate = entity.LastClosingDate.ToString("dd/MM/yyyy")
            };
        }

        public async Task<UpdateEventResponse?> UpdateEventAsync(UpdateEventRequest request)
        {
            using ( var transaction = _eventRepository.DatabaseTransaction())
            {
                try
                {
                    var entity = await _eventRepository.GetAsync(entity => entity.Id == request.Id);

                    if (entity == null)
                    {
                        return null;
                    }

                    entity.Id = request.Id;
                    entity.EventName = request.EventName;
                    entity.EventDescription = request.EventDescription;
                    entity.FirstClosingDate = request.FirstClosingDate;
                    entity.LastClosingDate = request.LastClosingDate;

                    _eventRepository.Update(entity);

                    _eventRepository.SaveChanges();

                    transaction.Commit();

                    return new UpdateEventResponse
                    {
                        Id = request.Id,
                        EventName = request.EventName,
                        EventDescription = request.EventDescription,
                        FirstClosingDate = request.FirstClosingDate.ToString("dd/MM/yyyy"),
                        LastClosingDate = request.LastClosingDate.ToString("dd/MM/yyyy")
                    };
                }
                catch
                {
                    transaction.Rollback();

                    return null;
                }
            }
        }
    }
}
