using API.DTOs.Category.CreateCategory;
using API.DTOs.Category.GetCategory;
using Common.DataType;

namespace API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request);

        Task<bool> DeleteCategoryAsync(int id);

        Task<Response<GetCategoryResponse>> GetByIdAsync(int id);

        Task<IEnumerable<GetCategoryResponse>> GetAllAsync();
    }
}
