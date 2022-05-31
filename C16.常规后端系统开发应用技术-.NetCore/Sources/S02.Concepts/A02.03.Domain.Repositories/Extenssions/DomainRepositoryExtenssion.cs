using WebApiConcepts.A02._01.Domain.Models;

namespace WebApiConcepts.A02._03.Domain.Repositories.Extenssions
{
    public static class DomainRepositoryExtenssion
    {
        /// <summary>
        /// 根据属性名称和对应的 Id，查找 DomainDataDbContext 中的对应的对象
        /// </summary>
        /// <typeparam name="TDdo"></typeparam>
        /// <param name="domainRepository"></param>
        /// <param name="domainModelName"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static async Task<object> GetByDomainModelNameAndId<TDdo>(
            this IDomainRepository<TDdo> domainRepository, 
            string domainModelName, 
            Guid objectId) where TDdo : class, IDataBase, new()
        {
            var  result= new object();
            var reposotory = domainRepository as DomainRepository<TDdo>;

            var dbSetProperty = reposotory?.DomainDataDbContext.GetType().GetProperties().FirstOrDefault(x=>x.Name == domainModelName);
            if (dbSetProperty != null)
            {
                var dbSet = dbSetProperty.GetValue(reposotory!.DomainDataDbContext) as IQueryable<IData>;

                if (dbSet != null)
                {
                    result = await dbSet.FirstOrDefaultAsync(x=>x.Id == objectId);
                    return result! as object;
                }
            }
            return result! as object;
        }
    }
}
