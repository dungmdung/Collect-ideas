using API.DTOs.Idea.CreateIdea;
using API.DTOs.Idea.CreateIdeaDetail;
using API.DTOs.Idea.GetIdea;
using API.DTOs.Idea.UpdateIdea;
using Application.Common;

namespace API.Services.Interfaces
{
    public interface IIdeaService
    {
        Task<Response<CreateIdeaResponse?>> CreateIdeaAsync(CreateIdeaRequest request);

        Task<CreateIdeaDetailResponse?> CreateIdeaDetailAsync(CreateIdeaDetailRequest request);

        Task<GetIdeaResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetIdeaResponse>> GetAllAsync();

        Task<UpdateIdeaResponse?> UpdateIdeaAsync(UpdateIdeaRequest request);

        Task<bool> DeleteIdeaAsync(int id);
    }
}
