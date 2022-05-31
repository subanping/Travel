namespace DataCURD.A03._02.Dto.Services.Helpers
{
    /// <summary>
    /// Dto 映射器
    /// </summary>
    public static class DtoMapper
    {
        /// <summary>
        /// 根据传入的领域对象，生成对应的数据传输对象，并返回
        /// </summary>
        /// <typeparam name="TDdo"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="ddo"></param>
        /// <returns></returns>
        public static TDto GetDto<TDdo, TDto>(TDdo ddo) 
            where TDdo : class, IDataBase, new ()
            where TDto : class, IDtoModelBase, new ()
        {
            var dto = new TDto ();
            // 提取领域对象模型的属性
            PropertyInfo[] ddoPropertyCollection = typeof(TDdo).GetProperties();
            // 提取传输对象模型的属性
            PropertyInfo[] dtoPropertyCollection = typeof(TDto).GetProperties();

            if (ddo == null)
                return dto;
            else
            {
                foreach (var ddoProperty in ddoPropertyCollection)
                {
                    // 获取领域对象模型属性名称
                    var ddoPropertyTypeName = ddoProperty.PropertyType.Name;
                    // 获取领域对象模型属性的全名
                    var ddoPropertyTypeFullName = ddoProperty.PropertyType.FullName;

                    // 先处理简单的属性，如果全名中不包含 “Domain.Models” 则认为是简单属性
                    if (!ddoPropertyTypeFullName!.Contains("Domain.Models"))
                    {
                        // 根据简单属性同名映射原则，获取传输对象模型属性
                        var dtoProperty = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name);
                        if (dtoProperty != null)
                        {
                            // 提取领域对象模型属性的值
                            var ddoPropertyValue = ddoProperty.GetValue(ddo);
                            // 赋值给传输对象模型属性
                            dtoProperty.SetValue(dto, ddoPropertyValue);
                        }
                    }
                    else
                    {
                        if (ddoPropertyTypeFullName.Contains("Domain.Models"))
                        {
                            // 先处理可能的 Parent
                            if (ddoPropertyTypeName == typeof(TDdo).Name && ddoProperty.Name == "Parent")
                            {
                                var ddoPropertyValue = ddoProperty.GetValue(ddo) as TDdo;
                                if (ddoPropertyValue != null)
                                {
                                    // 为传输的默认属性 ParentId, ParentName 赋值
                                    var dtoPrentId = ddoPropertyCollection.FirstOrDefault(x => x.Name == "ParentId");
                                    if (dtoPrentId != null)
                                        dtoPrentId.SetValue(dto, ddoPropertyValue.Id);

                                    var dtoPrentName = dtoPropertyCollection.FirstOrDefault(x => x.Name == "ParentName");
                                    if (dtoPrentName != null)
                                    {
                                        var nameProperty = ddoPropertyValue.GetType().GetProperty("Name");
                                        if (nameProperty != null)
                                        {
                                            dtoPrentName.SetValue(dto, nameProperty.GetValue(ddoPropertyValue));
                                        }

                                    }

                                }
                            }
                            else
                            {
                                // 处理其他的导航属性的值
                                var ddoPropertyValue = ddoProperty.GetValue(ddo) as IData;
                                if (ddoPropertyValue != null)
                                {
                                    // 提取传输对象关联的 Id 的属性
                                    var dtoPropertyForId = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name + "Id");
                                    if (dtoPropertyForId != null)
                                    {
                                        dtoPropertyForId.SetValue(dto, ddoPropertyValue.Id);
                                    }
                                    // 提传输端关联的 Id 的属性
                                    var dtoPropertyForName = dtoPropertyCollection.FirstOrDefault(x => x.Name == ddoProperty.Name + "Name");
                                    if (dtoPropertyForName != null)
                                    {
                                        dtoPropertyForName.SetValue(dto, ddoPropertyValue.Name);
                                    }
                                }
                            }
                        }
                    }
                }
                return dto;

            }
        }

        /// <summary>
        /// 根据传入的领域对象的分页方式的集合，生成并返回对应的数据传输对象的分页集合
        /// </summary>
        /// <typeparam name="TDdo"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="ddoDataPager"></param>
        /// <returns></returns>
        public static DataPager<TDto> GetDataPager<TDdo, TDto>(DataPager<TDdo> ddoDataPager)
            where TDdo : class, IDataBase, new()
            where TDto : class, IDtoModelBase, new()
        {
            var dtoDataPager= new DataPager<TDto>();

            var counter = (ddoDataPager.PageIndex - 1) * ddoDataPager.PageSize;
            foreach (var ddo in ddoDataPager!.DataCollection!)
            {
                var dto = GetDto<TDdo, TDto>(ddo);
                dto.OrderNumber = (++counter).ToString();
                dtoDataPager.DataCollection.Add(dto);
            }
            dtoDataPager.PageIndex = ddoDataPager.PageIndex;
            dtoDataPager.PageSize = ddoDataPager.PageSize;
            dtoDataPager.TotalCount = ddoDataPager.TotalCount;
            dtoDataPager.TotalPageCount = ddoDataPager.TotalPageCount;
            dtoDataPager.HasNextPage = ddoDataPager.HasNextPage;
            dtoDataPager.HasPreviousPage = ddoDataPager.HasPreviousPage;

            return dtoDataPager;
        }
    }
}
