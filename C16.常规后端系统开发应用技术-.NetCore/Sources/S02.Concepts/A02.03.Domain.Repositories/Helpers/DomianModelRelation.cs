namespace WebApiConcepts.A02._03.Domain.Repositories.Helpers
{
    /// <summary>
    /// 领域模型数据处理的一些助理方法
    /// </summary>
    public static class DomianModelRelation
    {
        /// <summary>
        /// 提取包含属性的表达式
        /// </summary>
        /// <typeparam name="TDdo"></typeparam>
        /// <returns></returns>
        public static List<Expression<Func<TDdo, object>>> GetIncludeExpression<TDdo>() where TDdo : class, IDataBase, new()
        {
            var result = new List<Expression<Func<TDdo, object>>>();

            PropertyInfo[] ddoPropertyCollection = typeof(TDdo).GetProperties();
            foreach (var ddoProperty in ddoPropertyCollection)
            {
                var ddoPropertyTypeName = ddoProperty.PropertyType.Name;
                var ddoPropertyTypeFullName = ddoProperty.PropertyType.FullName;

                if (ddoPropertyTypeFullName!.Contains("Domain.Models"))
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(TDdo), "i");
                    var property = Expression.Property(parameter, ddoProperty.Name);
                    var lambda = Expression.Lambda<Func<TDdo, object>>(property, parameter);
                    result.Add(lambda);
                }

            }
            return result;
        }

        public static void SetInclude<TDdo>(IQueryable<TDdo> dbSet) where TDdo : class, IDataBase, new()
        {
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }
        }
    }
}
