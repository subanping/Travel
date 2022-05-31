namespace WebApiStartup.RequestServices
{
    /// <summary>
    /// 针对学生数据请求对象服务接口 <see cref="IStudentRequestService" /> 的具体实现。
    /// </summary>
    public class StudentRequestService: IStudentRequestService
    {
        /// <summary>
        /// 班级仓储
        /// </summary>
        private readonly ITeachClassRepository? _teachClassRepository;
        /// <summary>
        /// 学生仓储
        /// </summary>
        private readonly IStudentRepository? _studentRepository;

        public StudentRequestService(ITeachClassRepository teachClassRepository, IStudentRepository studentRepository)
        {
            _teachClassRepository = teachClassRepository;
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// 根据请求对象的相关数据，生成检索条件，供 Dto 服务获取数据所需的查询条件使用
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public Expression<Func<Student, bool>> GetSearchPredicat(StudentSearchRequest searchRequest) 
        {
            // 仅仅演示根据姓名的查询条件
            Expression<Func<Student, bool>> predicate = x => x.Name!.Contains(string.Empty);
            if (!string.IsNullOrEmpty(searchRequest.Name)) 
            {
                predicate = x => x.Name!.Contains(searchRequest.Name); 
            }
            return predicate!;
        }

        /// <summary>
        /// 添加学生数据，负责将接受的学生数据请求对象，转换为学生数据领域对象，并添加到仓储中
        /// </summary>
        /// <param name="studentRequest"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(StudentRequest studentRequest) 
        {
            // 创建学生数据领域对象
            var student = new Student();
            // 将学生数据请求对象的属性值，映射到学生数据领域对象中
            await _MapperRequest(student, studentRequest);
            // 提交学生数据领域对象到仓储的添加方法中，并获取返回的处理状态
            return await _studentRepository!.AddAsync(student);
        }

        /// <summary>
        /// 更新学生数据
        /// </summary>
        /// <param name="studentRequest"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(StudentRequest studentRequest)
        {
            // 从仓储中提取学生数据领域对象
            var student = await _studentRepository!.GetAsync(studentRequest.Id);
            if (student == null)
                return false;
            else
            {
                // 将学生数据请求对象的属性值，映射到学生数据领域对象中
                await _MapperRequest(student, studentRequest);
                // 提交给仓储更新学生数据领域对象的方法进行处理，并返回处理状态
                return await _studentRepository.UpdateAsync(student);
            }
        }

        /// <summary>
        /// 删除学生数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            // 提交给仓储执行删除并返回处理状态
            return await _studentRepository!.DeleteAsync(id);
        }

        /// <summary>
        /// 学生数据领域对象更新方法
        /// </summary>
        /// <param name="student">学生数据领域对象</param>
        /// <param name="studentRequest">学生数据请求对象</param>
        /// <returns></returns>
        private async Task _MapperRequest(Student student, StudentRequest studentRequest)
        {
            student.Name = studentRequest.Name;
            student.Description = studentRequest.Description;
            student.SortCode = studentRequest.SortCode;
            student.BirthDay = studentRequest.BirthDay;
            student.Gender = studentRequest.Gender;
            student.Province = studentRequest.Province;
            if (studentRequest.TeachClassId != Guid.Empty)
            {
                student.TeachClass = 
                    await _teachClassRepository!.FindByIdAsync(studentRequest.TeachClassId);
            }
        }
    }
}
