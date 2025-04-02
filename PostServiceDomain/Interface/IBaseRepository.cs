using System.Linq.Expressions;

namespace PostServiceDomain.Interface
{
    public interface IBaseRepository
    {

        public interface IBaseRepository<T> where T : class //, new()
        {
            #region 异步


            /// <summary>
            /// 查找 -通过id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            Task<T> FindAsync(Guid id);

            /// <summary>
            /// 根据条件获取实体对象
            /// </summary>
            /// <param name="whereLambda"></param>
            /// <returns></returns>
            Task<T> QueryAsync(Expression<Func<T, bool>> whereLambda);

            /// <summary>
            /// 根据条件获取实体对象集合
            /// </summary>
            /// <param name="whereLambda"></param>
            /// <returns></returns>
            Task<List<T>> QueryListAsync(Expression<Func<T, bool>> whereLambda);

            /// <summary>
            /// 根据条件获取实体对象集合 包括删除数据
            /// </summary>
            /// <param name="whereLambda"></param>
            /// <returns></returns>
            Task<List<T>> QueryListIncludeDeleteAsync(Expression<Func<T, bool>> whereLambda);
            /// <summary>
            /// 根据条件获取实体对象集合分页
            /// </summary>
            /// <param name="whereLambda"></param>
            /// <param name="pageIndex"></param>
            /// <param name="pageSize"></param>
            /// <param name="totalCount"></param>
            /// <returns></returns>
            Task<(List<T>, int)> QueryListAsync(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, Expression<Func<T, object>> orderbyWhere);


            /// <summary>
            /// 新增
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="writeOrRead"></param>
            /// <returns></returns>
            Task AddAsync(T entity);

            /// <summary>
            /// 更新
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            Task UpdateAsync(T entitye);

            /// <summary>
            /// 删除
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            Task HardDeleteAsync(T entitye);

            /// <summary>
            /// 根据条件删除
            /// </summary>
            /// <param name="whereLambda"></param>
            /// <returns></returns>
            Task HardDeleteByWhereAsync(Expression<Func<T, bool>> whereLambda);


            #endregion
        }
    }

}
