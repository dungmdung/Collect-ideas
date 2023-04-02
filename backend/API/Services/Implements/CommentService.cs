using API.DTOs.Category.CreateCategory;
using API.DTOs.Comment.CreateComment;
using API.DTOs.Comment.GetComment;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Data.Entities;

namespace API.Services.Implements
{
    public class CommentService : ICommentService
    {
        private readonly IUserRepository _userRepository;

        private readonly ICommentRepository _commentRepository;

        private readonly IIdeaRepository _ideaRepository;
        public CommentService(IUserRepository userRepository, ICommentRepository commentRepository, IIdeaRepository ideaRepository)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _ideaRepository = ideaRepository;
        }
        public async Task<Response<CreateCommentResponse>> CreateCommentAsync(CreateCommentRequest request)
        {
            using (var transaction = _commentRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == request.UserId);

                    var idea = await _ideaRepository.GetAsync(idea => idea.Id == request.IdeaId);

                    if (user == null && idea == null)
                    {
                        return new Response<CreateCommentResponse>(false, ErrorMessages.NotFound);
                    }

                    var newEntity = new Comment
                    {
                        CommentContent = request.CommentContent,
                        UserId = request.UserId,
                        IdeaId = request.IdeaId,
                        DateSubmitted = DateTime.UtcNow
                    };

                    var newComment = _commentRepository.Create(newEntity);

                    var responseData = new CreateCommentResponse(newComment);

                    _commentRepository.SaveChanges();

                    transaction.Commit();

                    return new Response<CreateCommentResponse>(true, Messages.ActionSuccess, responseData);
                }

                catch
                {
                    transaction.Rollback();

                    return new Response<CreateCommentResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }

        public async Task<IEnumerable<GetCommentResponse>> GetAllAsync()
        {
            return (await _commentRepository.GetAllAsync())
                .Select(comment => new GetCommentResponse(comment));
        }

        public async Task<Response<GetCommentResponse>> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetAsync(comment => comment.Id == id);

            if(comment == null)
            {
                return new Response<GetCommentResponse>(false, ErrorMessages.NotFound);
            }

            var responseData = new GetCommentResponse(comment);

            return new Response<GetCommentResponse>(true, Messages.ActionSuccess, responseData);
        }
    }
}
