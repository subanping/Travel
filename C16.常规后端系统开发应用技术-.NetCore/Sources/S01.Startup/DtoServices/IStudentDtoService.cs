namespace WebApiStartup.DtoServices
{
    /// <summary>
    /// 学生数据传输对象处理服务接口，负责访问学生数据领域对象仓储，获取学生领域对象后。通过相应的方法转换为
    /// 学生数据传输对象供 API 控制器使用。一般来说可简单划分为获取单一 Dto 对象以及获取 Dto 对象集合两类。
    /// </summary>
    public interface IStudentDtoService
    {
        /// <summary>
        /// 根据对象的 Id 获取相应的 Dto 对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDto> GetDtoAsync(Guid id);

        /// <summary>
        /// 根据查询条件，按分页方式，获取学生数据传输对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条目数量</param>
        /// <returns></returns>
        Task<DataPaginated<StudentDto>> GetDtoDataPaginated(Expression<Func<Student, bool>> predicate, int pageIndex, int pageSize);

    }
}
