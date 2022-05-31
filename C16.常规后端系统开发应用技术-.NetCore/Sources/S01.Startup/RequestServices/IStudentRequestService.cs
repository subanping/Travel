namespace WebApiStartup.RequestServices
{
    /// <summary>
    /// 学生数据请求对象服务接口，生成相应的查询条件供数据传输对象服务使用，
    /// 以及根据数据处理请求对象（值对象），将请求对象提交到领域对象仓储中进行处理，并返回处理结果状态信息。
    /// </summary>
    public interface IStudentRequestService
    {
        /// <summary>
        /// 根据请求对象的相关数据，生成检索条件，供 Dto 服务获取数据所需的查询条件使用
        /// </summary>
        /// <param name="searchRequest">检索条件请求对象</param>
        /// <returns></returns>
        Expression<Func<Student, bool>> GetSearchPredicat(StudentSearchRequest searchRequest);

        /// <summary>
        /// 添加学生数据，负责将接受的学生数据请求对象，转换为学生数据领域对象，并添加到仓储中
        /// </summary>
        /// <param name="studentRequest"></param>
        /// <returns></returns>
        Task<bool> AddAsync(StudentRequest studentRequest);

        /// <summary>
        /// 更新学生数据，负责将接受的学生数据请求对象，更换到仓储中 Id 相同的为学生数据领域对象里。
        /// </summary>
        /// <param name="studentRequest"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(StudentRequest studentRequest);

        /// <summary>
        /// 删除学生数据，负责将仓储中 Id 相同的学生数据领域对象删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
