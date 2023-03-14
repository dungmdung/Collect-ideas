using API.DTOs.Idea.CreateIdea;
using API.DTOs.Idea.CreateIdeaDetail;
using API.DTOs.Idea.GetIdea;
using API.DTOs.Idea.UpdateIdea;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Application.Common;
using Common.Constant;
using Data.Entities;
using System.Transactions;

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

        public async Task<Response<CreateIdeaResponse?>> CreateIdeaAsync(CreateIdeaRequest request)
        {
            using (var trasaction = _ideaRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == request.UserId);

                    var events = await _eventRepository.GetAsync(events => events.Id == request.EventId);

                    if (user == null || events == null) { return null; }

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

                    _ideaRepository.SaveChanges();

                    trasaction.Commit();

                    var responseData = new CreateIdeaResponse(newIdea);

                    return new Response<CreateIdeaResponse>(true, responseData);
                }
                catch
                {
                    trasaction.Rollback();

                    return null;
                }
            }
        }

        public Task<CreateIdeaDetailResponse?> CreateIdeaDetailAsync(CreateIdeaDetailRequest request)
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
                .Select(idea => new GetIdeaResponse
                {
                    Id = idea.Id,
                    IdeaTitle = idea.IdeaTitle,
                    IdeaDescription = idea.IdeaDescription,
                    DateSubmitted = DateTime.UtcNow,
                    File = idea.File,
                    UserId = idea.UserId,
                    EventId = idea.EventId
                });
        }

        public async Task<GetIdeaResponse?> GetByIdAsync(int id)
        {
            var idea = await _ideaRepository.GetAsync(idea => idea.Id == id);

            if(idea == null)
            {
                return null;
            }

            return new GetIdeaResponse
            {
                Id = idea.Id,
                IdeaTitle = idea.IdeaTitle,
                IdeaDescription = idea.IdeaDescription,
                DateSubmitted = DateTime.UtcNow,
                File = idea.File,
                UserId = idea.UserId,
                EventId = idea.EventId
            };
        }

        public async Task<UpdateIdeaResponse?> UpdateIdeaAsync(UpdateIdeaRequest request)
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
                        idea.File = request.File;
                        idea.UserId = request.UserId;
                        idea.EventId = request.EventId;

                        var updateIdea = _ideaRepository.Update(idea);

                        _ideaRepository.SaveChanges();

                        trasaction.Commit();

                        return new UpdateIdeaResponse
                        {
                            Id = updateIdea.Id,
                            IdeaTitle = updateIdea.IdeaTitle,
                            IdeaDescription = updateIdea.IdeaDescription,
                            DateSubmitted = DateTime.UtcNow,
                            File = updateIdea.File,
                            UserId = updateIdea.UserId,
                            EventId = updateIdea.EventId
                        };
                    }

                    return null;
                }
                catch
                {
                    trasaction.Rollback();

                    return null;
                }
            }
        }
    }
}
