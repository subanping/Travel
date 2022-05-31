using DataCURD.A02._03.Domain.Repositories.Extenssions;
namespace DataCURD.A04._02.Request.Services.Helpers
{
    public static class RequestMapper
    {
        public static async Task SetDomainObject<TDdo, TRequest>(TDdo ddo, TRequest request, IDomainRepository<TDdo> domainRepository)
            where TDdo : class, IDataBase, new ()
            where TRequest : class, IRequestModelBase, new ()
        {

            PropertyInfo[] ddoPropertyCollection = typeof(TDdo).GetProperties();
            PropertyInfo[] requestPropertyCollection = typeof(TRequest).GetProperties();

            foreach (var requestProperty in requestPropertyCollection)
            {
                var requestPropertyTypeName = requestProperty.PropertyType.Name;
                var requestPropertyName = requestProperty.Name;

                if (requestPropertyName != "Id")
                {
                    #region 处理简单属性的值映射
                    var ddoProperty = ddoPropertyCollection.FirstOrDefault(x => x.Name == requestPropertyName);
                    if (ddoProperty != null)
                    {
                        var requestPropertyValue = requestProperty.GetValue(request);
                        ddoProperty.SetValue(ddo, requestPropertyValue);
                    }
                    #endregion

                    #region 处理关联属性
                    if(requestPropertyName.Contains("Id") && requestPropertyName.Length > 2)
                    {
                        var ddoRelationPropertyName = requestPropertyName.Substring(0, requestPropertyName.Length-2);
                        var ddoRelationProperty = ddoPropertyCollection.FirstOrDefault(x => x.Name == ddoRelationPropertyName);
                        
                        if (ddoRelationProperty != null)
                        {
                            if (requestProperty.GetValue(request) != null)
                            {
                                var endString= ddoRelationPropertyName.Substring(ddoRelationPropertyName.Length - 1, 1).ToLower();
                                if (endString == "s")
                                    ddoRelationPropertyName = ddoRelationPropertyName + "es";
                                else
                                {
                                    if(endString == "y")
                                    {
                                        ddoRelationPropertyName = ddoRelationPropertyName.Substring(0, ddoRelationPropertyName.Length - 1) + "ies";
                                    }
                                    else
                                    {
                                        ddoRelationPropertyName = ddoRelationPropertyName + "s";
                                    }
                                }
                                var requestPropertyValue = (Guid)requestProperty!.GetValue(request)!;
                                object ddoRelationPropertyValue = await domainRepository.GetByDomainModelNameAndId(ddoRelationPropertyName, requestPropertyValue);
                                ddoRelationProperty.SetValue(ddo, ddoRelationPropertyValue);
                            }
                        }
                    }
                    #endregion

                }

            }
        }

        public static void SetApplicationUserObject(ApplicationUserRequest user, ApplicationUserRequest userRequest)
        {
            user.UserName = userRequest.UserName;
            user.PhoneNumber = userRequest.PhoneNumber;
            user.Email = userRequest.Email;
        }
    }
}
