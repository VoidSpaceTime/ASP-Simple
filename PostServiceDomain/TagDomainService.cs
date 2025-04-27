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
//    public class TagDomainService
//    {
//        private readonly IBaseRepository<Tag> repositoryTag;

//        public TagDomainService(IBaseRepository<Tag> repositoryTag)
//        {
//            this.repositoryTag = repositoryTag;
//        }
//        public async Task<List<Tag>> QueryTagListByNameAsync(string name)
//        {
//            return await repositoryTag.QueryListAsync(o => o.Name.Contains(name));
//        }
//        public async Task<(List<Tag>, int)> QueryTagListByNameAsync(string name, int pageIndex, int pageSize, Expression<Func<Tag, object>> orderbyWhere, bool isAscending)
//        {
//            return await repositoryTag.QueryListAsync(o => o.Name.Contains(name), pageIndex, pageSize, orderbyWhere, isAscending);
//        }
//        public async Task CareteTag(string name, Guid ownerPostId)
//        {
//            var tag = Tag.Create(name, ownerPostId);
//            await repositoryTag.AddAsync(tag);
//        }
//        public async Task AddTag(List<string> names, Guid ownerPostId)
//        {
//            foreach (var name in names)
//            {
//                var tag = Tag.Create(name, ownerPostId);
//                await repositoryTag.AddAsync(tag);
//            }
//        }
//        public async Task HardDeleteAsync(long id)
//        {
//            var tag = await repositoryTag.QueryAsync(o => o.Id == id);
//            if (tag != null)
//            {
//                await repositoryTag.HardDeleteAsync(tag);
//            }
//        }
//        public async Task HardDeleteAsync(Guid ownerPostId)
//        {
//            var tag = await repositoryTag.QueryAsync(o => o.OwnerPostId == ownerPostId);
//            if (tag != null)
//            {
//                await repositoryTag.HardDeleteAsync(tag);
//            }
//        }
//    }
//}
