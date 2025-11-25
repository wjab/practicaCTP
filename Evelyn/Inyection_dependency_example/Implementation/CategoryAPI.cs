using AutoMapper;
using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;
using Microsoft.EntityFrameworkCore;

namespace Inyection_dependency_example.Implementation
{
    public class CategoryAPI : ICategoryAPI
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryAPI(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategory()
        {
            var CategoryList = await context.CategoryDB.Select(x => x).ToListAsync();
            return mapper.Map<List<CategoryDTO>>(CategoryList);
        }

        public async Task<CategoryDTO?> GetById(int IdCategory)
        {
            var CategoryDB = await context.CategoryDB.Where(x => x.IdCategory == IdCategory).Select(x => x).FirstOrDefaultAsync();
            return mapper.Map<CategoryDTO>(CategoryDB);
        }

        public async Task<CategoryDTO?> Insert(CategoryDTO Category)
        {
            var CategoryDB = mapper.Map<CategoryDB>(Category);
            context.CategoryDB.Add(CategoryDB);
            await context.SaveChangesAsync();

            return mapper.Map<CategoryDTO>(CategoryDB);
        }

        public async Task<CategoryDTO?> Update(int IdCategory, CategoryDTO Category)
        {
            var CategoryDB = await context.CategoryDB.Where(x => x.IdCategory == IdCategory).Select(x => x).FirstOrDefaultAsync();
            if (CategoryDB == null)
            {
                throw new Exception($"CategoryId {IdCategory} does not exists in database");
            }

            CategoryDB.CategoryName = Category.CategoryName ?? CategoryDB.CategoryName;
            await context.SaveChangesAsync();

            return mapper.Map<CategoryDTO>(CategoryDB);
        }
    }
}