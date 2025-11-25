using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface ICategoryAPI
    {
        Task<CategoryDTO?> GetById(int IdCategory);

        Task<List<CategoryDTO>> GetCategory();

        Task<CategoryDTO?> Insert(CategoryDTO Category);

        Task<CategoryDTO?> Update(int IdCategory, CategoryDTO Category);
    }
}
