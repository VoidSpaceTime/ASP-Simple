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

        public static Category Create(string name, Guid ownerPostId)
        {
            return new Category()
            {
                Name = name,
                OwnerPostId = ownerPostId,
            };
        }
        public async Task<List<Guid>> QueryPostListByCategoryId(long categoryId)
        {
            var category = await repositoryCategory.QueryListAsync(o => o.Id == categoryId);
            return category.Select(o => o.OwnerPostId).ToList();
        }
        public async Task<List<Guid>> QueryPostListByCategoryId(long categoryId, int pageIndex, int pageSize, Expression<Func<Category, object>> orderbyWhere)
        {
            var (category, idx) = await repositoryCategory.QueryListAsync(o => o.Id == categoryId, pageIndex, pageSize, orderbyWhere);
            return category.Select(o => o.OwnerPostId).ToList();
        }
        public async Task<List<Guid>> QueryPostListByCategoryName(string name)
        {
            var category = await repositoryCategory.QueryListAsync(o => o.Name == name);
            return category.Select(o => o.OwnerPostId).ToList();
        }
    }
}
