//using PostServiceDomain.Entity;
//using PostServiceDomain.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using static PostServiceDomain.Interface.IBaseRepository;

//namespace PostServiceDomain
//{
//    public class CategoryDomainService
//    {
//        private readonly IBaseRepository<Category> repositoryCategory; // Fix: Corrected the generic type to Category

//        public CategoryDomainService(IBaseRepository<Category> repositoryCategory) // Fix: Corrected the generic type to Category
//        {
//            this.repositoryCategory = repositoryCategory;
//        }

//        public async Task<List<Category>> QueryAllCategoriesAsync()
//        {
//            return await repositoryCategory.QueryListAsync(o => true);
//        }

//        public async Task<Category> GetCategoryByIdAsync(long Id)
//        {
//            return await repositoryCategory.QueryAsync(o => o.Id == Id);
//        }

//        public async Task<Category> GetCategoryByNameAsync(string name)
//        {
//            return await repositoryCategory.QueryAsync(o => o.Name == name);
//        }

//        public async Task<List<Category>> QueryPostByNameAsync(List<string> names)
//        {
//            var categories = new List<Category>();
//            foreach (var name in names)
//            {
//                var category = await repositoryCategory.QueryAsync(o => o.Name == name);
//                if (category != null)
//                {
//                    categories.Add(category);
//                }
//            }
//            return categories;
//        }

//        public async Task HardDeleteCategoriesAsync(Category category)
//        {
//            await repositoryCategory.HardDeleteAsync(category);
//        }

//        public async Task<Category> CreateCategoryAsync(string name)
//        {
//            var category = await repositoryCategory.QueryAsync(o => o.Name == name);
//            if (category != null)
//            {
//                return category;
//            }
//            category = Category.Create(name);
//            await repositoryCategory.AddAsync(category);
//            return category;
//        }

//        public async Task<List<Category>> AddCategoryAsync(List<string> names, Guid PostId)
//        {
//            var categories = new List<Category>();
//            foreach (var name in names)
//            {
//                var category = await repositoryCategory.QueryAsync(o => o.Name == name);
//                if (category == null)
//                {
//                    category = Category.Create(name);
//                    await repositoryCategory.AddAsync(category);
//                    categories.Add(category);
//                }
//                else
//                {
//                    category.OwnerPostId.Add(PostId);
//                }
//                category.OwnerPostId.Add(PostId);
//            }
//            return categories;
//        }

//        public async Task DeletePostAsync(List<string> names, Guid postId)
//        {
//            foreach (var name in names)
//            {
//                var category = await repositoryCategory.QueryAsync(o => o.Name == name);
//                if (category != null)
//                {
//                    category.RemovePost(postId);
//                    if (category.OwnerPostId.Count == 0)
//                    {
//                        await repositoryCategory.HardDeleteAsync(category);
//                    }
//                    else
//                    {
//                        await repositoryCategory.UpdateAsync(category);
//                    }
//                }
//            }
//        }

//        public async Task DeletePostAsync(Guid postId)
//        {
//            var categories = await repositoryCategory.QueryListIncludeDeleteAsync(o => o.OwnerPostId.Contains(postId));
//            foreach (var category in categories)
//            {
//                category.RemovePost(postId);
//                if (category.OwnerPostId.Count == 0)
//                {
//                    await repositoryCategory.HardDeleteAsync(category);
//                }
//                else
//                {
//                    await repositoryCategory.UpdateAsync(category);
//                }
//            }
//        }
//    }
//}
