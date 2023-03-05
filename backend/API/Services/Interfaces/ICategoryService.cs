using API.DTOs.Category.CreateCategory;
using API.DTOs.User.CreateUser;

namespace API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponse?> CreateCategoryAsync(CreateCategoryRequest request);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
