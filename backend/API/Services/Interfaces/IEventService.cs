﻿using API.DTOs.Event.CreateEvent;
using API.DTOs.Event.GetEvent;
using API.DTOs.Event.UpdateEvent;
using Application.Common;

namespace API.Services.Interfaces
{
    public interface IEventService
    {
        Task<Response<GetEventResponse>> GetByIdAsync(int id);

        Task<IEnumerable<GetEventResponse>> GetAllAsync();

        Task<Response<CreateEventResponse>> CreateEventAsync(CreateEventRequest request);

        Task<Response<UpdateEventResponse>> UpdateEventAsync(UpdateEventRequest request);

        Task<bool> DeleteEventAsync(int id);
    }
}
