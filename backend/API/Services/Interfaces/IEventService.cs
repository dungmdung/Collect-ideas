using API.DTOs.Event.CreateEvent;
using API.DTOs.Event.GetEvent;
using API.DTOs.Event.UpdateEvent;

namespace API.Services.Interfaces
{
    public interface IEventService
    {
        Task<GetEventResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetEventResponse>> GetAllAsync();

        Task<CreateEventResponse?> CreateEventAsync(CreateEventRequest request);

        Task<UpdateEventResponse?> UpdateEventAsync(UpdateEventRequest request);

        Task<bool> DeleteEventAsync(int id);
    }
}
