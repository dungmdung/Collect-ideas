using API.DTOs.Category.CreateCategory;
using API.DTOs.Category.GetCategory;

namespace API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponse?> CreateCategoryAsync(CreateCategoryRequest request);

        Task<bool> DeleteCategoryAsync(int id);

        Task<GetCategoryResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetCategoryResponse>> GetAllAsync();
    }
}
