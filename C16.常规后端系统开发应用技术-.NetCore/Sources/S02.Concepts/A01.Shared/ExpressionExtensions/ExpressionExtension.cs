namespace WebApiConcepts.A01.Shared.ExpressionExtensions
{
    /// <summary>
    /// 这是一组用于处理 Lambda 表达式的工具和扩展方法
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// 根据表达式获取相关的泛型类型中的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static PropertyInfo? GetProperty<T>(Expression<Func<T, object>> expression)
        {
            MemberExpression? body = expression.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)expression.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body!.Member as PropertyInfo ;
        }

        /// <summary>
        /// 针对仓储泛型接口 <see cref="Expression{Func{T,bool}}" /> 的扩展方法，将两个表达式通过 Or 组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">第一个表达式</param>
        /// <param name="second">第二个表达式</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        /// <summary>
        /// Lambda表达式拼接处理的扩展方法       
        /// /// </summary>        
        /// /// <typeparam name="T"></typeparam>        
        /// /// <param name="first"></param>        
        /// /// <param name="second"></param>        
        /// /// <param name="merge">拼接的方式 And/Or </param>        
        /// /// <returns></returns>        
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // 创建参数映射器字典 (待拼接的表达式放在字典元素的第一个位置)            
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            // 使用字典元素重新绑定           
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// 获取泛型对象指定属性名的表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Expression<Func<T, TKey>> GetPropertyExpression<T, TKey>(string propertyName) where T : class, IDataBase, new()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, nameof(propertyName));
            var lambda = Expression.Lambda<Func<T, TKey>>(property, parameter);
            return lambda;
            //return Expression.Lambda<Func<T, TKey>>(Expression.Convert(Expression.Property(parameter, propertyName), typeof(object)), parameter);
        }

        /// <summary>
        /// 根据关键词，获取根据关键词查询的表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetConditionExpression<T>(string keyword) where T : class, IDataBase, new()
        {
            Expression<Func<T, bool>> expression = _GetContains<T>("Name", keyword);
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var item in properties)
            {
                var itemTypeName = item.PropertyType.Name;
                if (itemTypeName.ToLower() == "string" && item.Name != "Name")
                {
                    expression = expression.Or(_GetContains<T>(item.Name, keyword));
                }
            }
            return expression;
        }

        /// <summary>
        /// 根据关键词，以及指定的属性名称数组，获取相关的表达式（包含条件）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyword"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetConditionExpression<T>(string keyword, string[] names) where T : class, IData, new()
        {
            Expression<Func<T, bool>> expression = _GetContains<T>("Name", keyword);
            foreach (var item in names)
            {
                if (item != "Name")
                {
                    expression = expression.Or(_GetContains<T>(item, keyword));
                }
            }
            return expression;
        }

        /// <summary>
        /// 根据属性的名称和值，创建相等的条件表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetEqual<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.PropertyOrField(parameter, propertyName);
            MethodInfo? method = typeof(string).GetMethod("==", new[] { typeof(string) });
            ConstantExpression constant = Expression.Constant(propertyValue, typeof(Guid));

            return Expression.Lambda<Func<T, bool>>(Expression.Call(member, method!, constant), parameter);
        }

        /// <summary>
        /// 创建lambda表达式：x=>x.propertyName.Contains(propertyValue)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Expression<Func<T, bool>> _GetContains<T>(string propertyName, string propertyValue) where T : class, IDataBase, new()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.PropertyOrField(parameter, propertyName);
            MethodInfo? method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            ConstantExpression constant = Expression.Constant(propertyValue, typeof(string));

            return Expression.Lambda<Func<T, bool>>(Expression.Call(member, method!, constant), parameter);
        }

    }

    public class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression? from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression? Visit(Expression? node)
        {
            return node == from ? to : base.Visit(node);
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (map.TryGetValue(p, out ParameterExpression? replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }

}
