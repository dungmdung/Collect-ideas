﻿using API.DTOs.Event.CreateEvent;
using API.DTOs.Event.GetEvent;
using API.DTOs.Event.UpdateEvent;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Application.Common;
using Common.Constant;
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

        public async Task<Response<CreateEventResponse>> CreateEventAsync(CreateEventRequest request)
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

                    var responseData = new CreateEventResponse(newEvent);

                    _eventRepository.SaveChanges();

                    transaction.Commit();

                    return new Response<CreateEventResponse>(true, Messages.ActionSuccess, responseData);
                }
                catch
                {
                    transaction.Rollback();

                    return new Response<CreateEventResponse>(false, ErrorMessages.BadRequest);
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
                .Select(entity => new GetEventResponse(entity));
        }

        public async Task<Response<GetEventResponse>> GetByIdAsync(int id)
        {
            var entity = await _eventRepository.GetAsync(entity => entity.Id == id);

            if (entity == null)
            { 
                return new Response<GetEventResponse>(false, ErrorMessages.NotFound); 
            }

            var responseData = new GetEventResponse(entity);

            return new Response<GetEventResponse>(true, Messages.ActionSuccess, responseData);
        }

        public async Task<Response<UpdateEventResponse>> UpdateEventAsync(UpdateEventRequest request)
        {
            using ( var transaction = _eventRepository.DatabaseTransaction())
            {
                try
                {
                    var entity = await _eventRepository.GetAsync(entity => entity.Id == request.Id);

                    if (entity == null)
                    {
                        return new Response<UpdateEventResponse>(false, ErrorMessages.NotFound);
                    }

                    entity.Id = request.Id;
                    entity.EventName = request.EventName;
                    entity.EventDescription = request.EventDescription;
                    entity.FirstClosingDate = request.FirstClosingDate;
                    entity.LastClosingDate = request.LastClosingDate;

                    var responseDate = new UpdateEventResponse(entity);

                    _eventRepository.Update(entity);

                    _eventRepository.SaveChanges();

                    transaction.Commit();

                    return new Response<UpdateEventResponse>(true, Messages.ActionSuccess, responseDate);
                }
                catch
                {
                    transaction.Rollback();

                    return new Response<UpdateEventResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }
    }
}
