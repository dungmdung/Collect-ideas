using API.DTOs.Idea.CreateIdea;
using API.DTOs.Idea.ExportIdeaFile;
using API.DTOs.Idea.GetIdea;
using API.DTOs.Idea.GetListIdeas;
using API.DTOs.Idea.Statistical;
using API.DTOs.Idea.UpdateIdea;
using API.Helpers;
using API.Helpers.EmailHelper;
using API.Queries;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Common.Enums;
using Data.Entities;
using System.Text;

namespace API.Services.Implements
{
    public class IdeaService : IIdeaService
    {
        private readonly IIdeaRepository _ideaRepository;

        private readonly IUserRepository _userRepository;

        private readonly IEventRepository _eventRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IEmailService _emailService;

        public IdeaService(IIdeaRepository ideaRepository, IUserRepository userRepository
            , IEventRepository eventRepository, ICategoryRepository categoryRepository
            , IEmailService emailService)
        {
            _ideaRepository = ideaRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _emailService = emailService;
        }

        public Task<Response<StatisticalIdeaResponse>> countIdeas()
        {
            throw new NotImplementedException();
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
                        return new Response<CreateIdeaResponse>(false, ErrorMessages.NotFound); 
                    }

                    var categoryIds = request.CategoryIds.Distinct();

                    var categories = (List<Category>) await _categoryRepository
                        .GetAllAsync(category => categoryIds.Contains(category.Id));

                    if (categories.Count != categoryIds.Count())
                    {
                        return new Response<CreateIdeaResponse>(false, ErrorMessages.NotFound);
                    }

                    var newEntity = new Idea
                    {
                        IdeaTitle = request.IdeaTitle,
                        IdeaDescription = request.IdeaDescription,
                        DateSubmitted = DateTime.UtcNow,
                        File = request.File,
                        HashTag= request.HashTag,
                        UserId = request.UserId,
                        EventId = request.EventId,
                        Categories = categories
                    };

                    if( newEntity.DateSubmitted < events.FirstClosingDate || newEntity.DateSubmitted > events.LastClosingDate)
                    {
                        return new Response<CreateIdeaResponse>(false, ErrorMessages.InvalidDateSubmitted);
                    }

                    var newIdea = _ideaRepository.Create(newEntity);

                    var message = new Message(new string[] { events.User.Email }, "Got a new idea!!!"
                        , "Full Name: " + user.FullName + "\nDate Submitted: " 
                        + newIdea.DateSubmitted.ToString("dd/MM/yyyy") + "\nTitle Idea: " + newIdea.IdeaTitle 
                        + "\nIdea Description: " + newIdea.IdeaDescription + "\n\n\n" + newIdea.File);

                    await _emailService.SendEmailAsync(message);

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

        public async Task<string> ExportCSVFile(ExportIdeaFileRequest request)
        {
            var ideas = (await _ideaRepository.GetAllAsync()).Select(i => new GetIdeaResponse(i)).AsQueryable();

            var validFilterFields = new[]
            {
                ModelField.Department,
                ModelField.CategoryName,
                ModelField.EventName
            };

            var filterQueries = new List<FilterQuery>();

            if (!string.IsNullOrEmpty(request.IdeaFilter.Department))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.Department,
                    FilterValue = request.IdeaFilter.Department
                });
            }

            if (!string.IsNullOrEmpty(request.IdeaFilter.CategoryName))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.CategoryName,
                    FilterValue = request.IdeaFilter.CategoryName
                });
            }

            if (!string.IsNullOrEmpty(request.IdeaFilter.EventName))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.EventName,
                    FilterValue = request.IdeaFilter.EventName
                });
            }

            var processedList = ideas.MultipleFiltersByField(validFilterFields, filterQueries);

            string[] columnNames = new string[] { "Id", "IdeaTitle", "IdeaDescription", "DateSubmitted", "File", "Department", "Event", "Category" };

            string csv = string.Empty;

            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }

            csv += "\r\n";

            foreach (var idea in processedList)
            {
                csv += idea.Id.ToString().Replace(",", ";") + ',';
                csv += idea.IdeaTitle.Replace(",", ";") + ',';
                csv += idea.IdeaDescription.Replace(",", ";") + ',';
                csv += idea.DateSubmitted.ToString("dd/MM/yyyy").Replace(",", ";") + ',';
                csv += idea.File.Replace(",", ";") + ',';
                csv += idea.Department.ToString().Replace(",", ";") + ',';
                csv += idea.EventName.ToString().Replace(",", ";") + ',';
                csv += idea.Categories.ToString().Replace(",", ";") + ',';

                csv += "\r\n";
            }

            return csv;
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

        public async Task<Response<GetListIdeasResponse>> GetPagedListAsync(GetListIdeasRequest request)
        {
            var ideas = (await _ideaRepository.GetAllAsync()).Select(i => new GetIdeaResponse(i)).AsQueryable();

            var validSearchFields = new[]
            {
                ModelField.HashTag,
                ModelField.UserName
            };

            var validFilterFields = new[]
            {
                ModelField.Department,
                ModelField.CategoryName,
                ModelField.EventName
            };

            var filterQueries = new List<FilterQuery>();

            if (!string.IsNullOrEmpty(request.IdeaFilter.Department))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.Department,
                    FilterValue = request.IdeaFilter.Department
                });
            }

            if (!string.IsNullOrEmpty(request.IdeaFilter.CategoryName))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.CategoryName,
                    FilterValue = request.IdeaFilter.CategoryName
                });
            }

            if (!string.IsNullOrEmpty(request.IdeaFilter.EventName))
            {
                filterQueries.Add(new FilterQuery
                {
                    FilterField = ModelField.EventName,
                    FilterValue = request.IdeaFilter.EventName
                });
            }

            var processedList = ideas.MultipleFiltersByField(validFilterFields, filterQueries)
                .SearchByField(validSearchFields, request.SearchQuery.SearchValue);

            var pagedList = new PagedList<GetIdeaResponse>(processedList, request.PagingQuery.PageIndex,
                request.PagingQuery.PageSize);

            var responseData = new GetListIdeasResponse(pagedList);

            return new Response<GetListIdeasResponse>(true, Messages.ActionSuccess, responseData);
        }

        public async Task<Response<UpdateIdeaResponse>> UpdateIdeaAsync(UpdateIdeaRequest request)
        {
            using ( var trasaction = _ideaRepository.DatabaseTransaction())
            {
                try
                {
                    var idea = await _ideaRepository.GetAsync(idea => idea.Id == request.Id);

                    var categoryIds = request.CategoryIds.Distinct();

                    var categories = (List<Category>)await _categoryRepository
                        .GetAllAsync(category => categoryIds.Contains(category.Id));

                    if (categories.Count != categoryIds.Count())
                    {
                        return new Response<UpdateIdeaResponse>(false, ErrorMessages.NotFound);
                    }

                    if (idea != null)
                    {
                        var user = await _userRepository.GetAsync(user => user.Id == request.UserId);

                        var events = await _eventRepository.GetAsync(events => events.Id == request.EventId);

                        idea.IdeaTitle = request.IdeaTitle;
                        idea.IdeaDescription = request.IdeaDescription;
                        idea.DateSubmitted = DateTime.UtcNow;
                        idea.File = request.File;
                        idea.HashTag = request.HashTag;
                        idea.UserId = request.UserId;
                        idea.EventId = request.EventId;
                        idea.Categories = categories;

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
