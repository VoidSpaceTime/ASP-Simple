using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostServiceDomain
{
    class CategoryDomainService
    {
        private readonly ICategoryRepository repositoryCategory;

        public CategoryDomainService(ICategoryRepository repositoryCategory)
        {
            this.repositoryCategory = repositoryCategory;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await repositoryCategory.QueryListAsync(o => true);
        }
        public async Task<Category> QueryCategoryByIdAsync(long Id)
        {
            return await repositoryCategory.QueryAsync(o => o.Id == Id);
        }
        public async Task<Category> QueryCategoryNameAsync(string name)
        {
            return await repositoryCategory.QueryAsync(o => o.Name == name);
        }
        public async Task HardDeleteCategoriesAsync(Category category)
        {
            await repositoryCategory.HardDeleteAsync(category);
        }

        public async Task<Category> CreateCategoryAsync(string name)
        {
            var category = await repositoryCategory.QueryAsync(o => o.Name == name);
            if (category != null)
            {
                return category;
            }
            category = Category.Create(name);
            await repositoryCategory.AddAsync(category);
            return category;
        }
    }
}
