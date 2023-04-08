
using API.DTOs.Thumbs.GetThumbs;
using API.DTOs.Thumbs.Thumb;
using Common.DataType;

namespace API.Services.Interfaces
{
    public interface IThumbsService
    {

        Task<Response<ThumbResponse>> CreateThumbAsync(ThumbRequest request);

        Task<Response<GetThumbResponse>> GetByIdAsync(int id);

        Task<IEnumerable<GetThumbResponse>> GetAllAsync();
    }
}
