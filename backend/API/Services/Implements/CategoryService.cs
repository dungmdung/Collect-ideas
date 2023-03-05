using API.DTOs.Category.CreateCategory;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryResponse?> CreateCategoryAsync(CreateCategoryRequest request)
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

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return new CreateCategoryResponse
                    {
                        CategoryName = newCategory.CategoryName,
                        CategoryDescription = newCategory.CategoryDescription
                    };
                }
                catch
                {
                    transaction.Rollback();

                    return null;
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

                    if (category != null)
                    {
                        _categoryRepository.Delete(category);

                        _categoryRepository.SaveChanges();

                        transaction.Commit();
                    }

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
    }
}
