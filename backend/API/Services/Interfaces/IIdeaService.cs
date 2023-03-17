using API.DTOs.Idea.CreateIdea;
using API.DTOs.Idea.GetIdea;
using API.DTOs.Idea.UpdateIdea;
using Application.Common;

namespace API.Services.Interfaces
{
    public interface IIdeaService
    {
        Task<Response<CreateIdeaResponse>> CreateIdeaAsync(CreateIdeaRequest request);

        Task<Response<GetIdeaResponse>> GetByIdAsync(int id);

        Task<IEnumerable<GetIdeaResponse>> GetAllAsync();

        Task<Response<UpdateIdeaResponse>> UpdateIdeaAsync(UpdateIdeaRequest request);

        Task<bool> DeleteIdeaAsync(int id);
    }
}
