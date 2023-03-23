using API.DTOs.Category.CreateCategory;
using API.DTOs.Category.GetCategory;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Data.Entities;

namespace API.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<CreateCategoryResponse>> CreateCategoryAsync(CreateCategoryRequest request)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
            {
                try
                {
                    var newEntity = new Category
                    {
                        CategoryName = request.CategoryName,
                        CategoryDescription = request.CategoryDescription
                    };

                    var newCategory = _categoryRepository.Create(newEntity);

                    var responseData = new CreateCategoryResponse(newCategory);

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return new Response<CreateCategoryResponse>(true, Messages.ActionSuccess, responseData);
                }
                catch
                {
                    transaction.Rollback();

                    return new Response<CreateCategoryResponse>(true, ErrorMessages.BadRequest);
                }
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
            {
                try
                {
                    var category = await _categoryRepository.GetAsync(category => category.Id == id);

                    if (category == null)
                    {
                        return false;
                    }

                    _categoryRepository.Delete(category);

                    _categoryRepository.SaveChanges();

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

        public async Task<IEnumerable<GetCategoryResponse>> GetAllAsync()
        {
            return ( await _categoryRepository.GetAllAsync())
                .Select(category => new GetCategoryResponse(category));
        }

        public async Task<Response<GetCategoryResponse>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == id);

            if(category == null)
            {
                return new Response<GetCategoryResponse>(false, ErrorMessages.NotFound);
            }
            var responseData = new GetCategoryResponse(category);

            return new Response<GetCategoryResponse>(true, Messages.ActionSuccess, responseData);
        }
    }
}
