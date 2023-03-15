using API.DTOs.Idea.CreateIdea;
using API.DTOs.Idea.CreateIdeaDetail;
using API.DTOs.Idea.GetIdea;
using API.DTOs.Idea.UpdateIdea;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Application.Common;
using Common.Constant;
using Data.Entities;

namespace API.Services.Implements
{
    public class IdeaService : IIdeaService
    {
        public readonly IIdeaRepository _ideaRepository;

        public readonly IUserRepository _userRepository;

        public readonly IEventRepository _eventRepository;

        public IdeaService(IIdeaRepository ideaRepository, IUserRepository userRepository, IEventRepository eventRepository)
        {
            _ideaRepository = ideaRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Response<CreateIdeaResponse>> CreateIdeaAsync(CreateIdeaRequest request)
        {
            using (var trasaction = _ideaRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == request.UserId);

                    var events = await _eventRepository.GetAsync(events => events.Id == request.EventId);

                    if (user == null || events == null) 
                    { 
                        return new Response<CreateIdeaResponse>(false, ErrorMessages.BadRequest); 
                    }

                    var newEntity = new Idea
                    {
                        IdeaTitle = request.IdeaTitle,
                        IdeaDescription = request.IdeaDescription,
                        DateSubmitted = DateTime.UtcNow,
                        File = request.File,
                        UserId = request.UserId,
                        EventId = request.EventId,
                    };

                    if( newEntity.DateSubmitted < events.FirstClosingDate || newEntity.DateSubmitted > events.LastClosingDate)
                    {
                        return new Response<CreateIdeaResponse>(false, ErrorMessages.InvalidDateSubmitted);
                    }

                    var newIdea = _ideaRepository.Create(newEntity);

                    var responseData = new CreateIdeaResponse(newIdea);

                    _ideaRepository.SaveChanges();

                    trasaction.Commit();

                    return new Response<CreateIdeaResponse>(true, Messages.ActionSuccess , responseData);
                }
                catch
                {
                    trasaction.Rollback();

                    return new Response<CreateIdeaResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }

        public Task<Response<CreateIdeaDetailResponse>> CreateIdeaDetailAsync(CreateIdeaDetailRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteIdeaAsync(int id)
        {
            using (var transaction = _ideaRepository.DatabaseTransaction())
            {
                try
                {
                    var idea = await _ideaRepository.GetAsync(idea => idea.Id == id);

                    if ( idea == null) { return false; }

                    _ideaRepository.Delete(idea);

                    _ideaRepository.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public async Task<IEnumerable<GetIdeaResponse>> GetAllAsync()
        {
            return (await _ideaRepository.GetAllAsync())
                .Select(idea => new GetIdeaResponse(idea));
        }

        public async Task<Response<GetIdeaResponse>> GetByIdAsync(int id)
        {
            var idea = await _ideaRepository.GetAsync(idea => idea.Id == id);

            if(idea == null)
            {
                return new Response<GetIdeaResponse>(false, ErrorMessages.NotFound);
            }

            var responseData = new GetIdeaResponse(idea);

            return new Response<GetIdeaResponse>(true, Messages.ActionSuccess, responseData);
        }

        public async Task<Response<UpdateIdeaResponse>> UpdateIdeaAsync(UpdateIdeaRequest request)
        {
            using ( var trasaction = _ideaRepository.DatabaseTransaction())
            {
                try
                {
                    var idea = await _ideaRepository.GetAsync(idea => idea.Id == request.Id);

                    if (idea != null)
                    {
                        var user = await _userRepository.GetAsync(user => user.Id == request.UserId);

                        var events = await _eventRepository.GetAsync(events => events.Id == request.EventId);

                        idea.IdeaTitle = request.IdeaTitle;
                        idea.IdeaDescription = request.IdeaDescription;
                        idea.DateSubmitted = DateTime.UtcNow;
                        idea.File = request.File;
                        idea.UserId = request.UserId;
                        idea.EventId = request.EventId;

                        if (idea.DateSubmitted < events.FirstClosingDate || idea.DateSubmitted > events.LastClosingDate)
                        {
                            return new Response<UpdateIdeaResponse>(false, ErrorMessages.InvalidDateSubmitted);
                        }

                        var updateIdea = _ideaRepository.Update(idea);

                        var responseData = new UpdateIdeaResponse(updateIdea);

                        _ideaRepository.SaveChanges();

                        trasaction.Commit();

                        return new Response<UpdateIdeaResponse>(true, Messages.ActionSuccess, responseData);
                    }

                    return new Response<UpdateIdeaResponse>(false, ErrorMessages.NotFound);
                }
                catch
                {
                    trasaction.Rollback();

                    return new Response<UpdateIdeaResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }
    }
}
