using API.DTOs.Thumbs.GetThumbs;
using API.DTOs.Thumbs.Thumb;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Data.Entities;

namespace API.Services.Implements
{
    public class ThumbsService : IThumbsService
    {
        private readonly IThumbRespository _thumbRespository;

        private readonly IIdeaRepository _ideaRepository;

        public ThumbsService (IThumbRespository thumbRespository, IIdeaRepository ideaRepository)
        {
            _thumbRespository = thumbRespository;
            _ideaRepository = ideaRepository;
        }

        public async Task<Response<ThumbResponse>> CreateThumbAsync(ThumbRequest request)
        {
            using (var transaction = _thumbRespository.DatabaseTransaction())
            {
                try
                {
                    var idea = await _ideaRepository.GetAsync(idea => idea.Id == request.IdeaId);

                    if (idea == null)
                    {
                        return new Response<ThumbResponse>(false, ErrorMessages.NotFound);
                    }

                    var newEntity = new Thumb
                    {
                        ThumbType = request.ThumbType,
                        IdeaId = request.IdeaId,
                        UserId = request.UserId
                    };

                    var newThumb = _thumbRespository.Create(newEntity);

                    _thumbRespository.SaveChanges();

                    transaction.Commit();

                    var responseData = new ThumbResponse(newThumb);

                    return new Response<ThumbResponse>(true, Messages.ActionSuccess, responseData);
                }
                catch
                {
                    transaction.Rollback();

                    return new Response<ThumbResponse>(false, ErrorMessages.BadRequest);
                }

            } 
        }

        public Task<IEnumerable<GetThumbResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetThumbResponse>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
