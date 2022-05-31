namespace WebApiStartup.DtoServices
{
    /// <summary>
    /// 针对学生数据传输对象服务处理接口 <see cref="IStudentDtoService" /> 的具体实现。
    /// </summary>
    public class StudentDtoService: IStudentDtoService
    {
        /// <summary>
        /// 学生数据领域对象的仓储数据访问接口
        /// </summary>
        private readonly IStudentRepository? _studentRepository;

        /// <summary>
        /// 构造函数，注入接口映射实现
        /// </summary>
        /// <param name="studentRepository"></param>
        public StudentDtoService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto> GetDtoAsync(Guid id)
        {
            // 获取学生数据领域模型对象
            var student = await _studentRepository!.GetAsync(id);
            // 转换为学生 Dto 对象并返回
            return _DtoMapper(student);
        }

        public async Task<DataPaginated<StudentDto>> GetDtoDataPaginated(Expression<Func<Student, bool>> predicate, int pageIndex, int pageSize)
        {
            // 根据查询条件和分页规格数据，获取学生数据领域对象集合
            var studentDataPaginated = await _studentRepository!.GetDataPaginatedList(predicate, pageIndex, pageSize);
            // 创建学生数据传输对象集合分页对象
            var studentDtoDataPaginated= new DataPaginated<StudentDto>();
            // 创建起始序号
            var counter = (pageIndex - 1) * pageSize;

            foreach(var student in studentDataPaginated.DataCollection)
            {
                // 将领域对象转换为传输对象
                var studentDto= _DtoMapper(student);
                // 处理序号
                studentDto.OrderCode=(++counter).ToString();
                // 添加到分页对象的数据容器中
                studentDtoDataPaginated.DataCollection.Add(studentDto);
            }
            #region 处理分页相关的规格数据
            studentDtoDataPaginated.PageIndex       = pageIndex;
            studentDtoDataPaginated.PageSize        = pageSize;
            studentDtoDataPaginated.TotalCount      = studentDataPaginated.TotalCount;
            studentDtoDataPaginated.TotalPageCount  = studentDataPaginated.TotalPageCount;
            studentDtoDataPaginated.HasNextPage     = studentDataPaginated.HasNextPage;
            studentDtoDataPaginated.HasPreviousPage = studentDataPaginated.HasPreviousPage; 
            #endregion

            return studentDtoDataPaginated;
        }

        /// <summary>
        /// 学生数据传输对象映射处理方法，将传入的数据领域对象，转换为数据传输对象
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private StudentDto _DtoMapper(Student student)
        {
            var studentDto = new StudentDto();
            if (student != null)
            {
                studentDto.Id = student.Id;
                studentDto.Name = student.Name;
                studentDto.Description = student.Description;
                studentDto.SortCode = student.SortCode;
                studentDto.BirthDay = student.BirthDay.ToLocalTime();
                studentDto.Gender = student.Gender;
                studentDto.Province = student.Province;

                if (student.TeachClass != null)
                {
                    studentDto.TeachClassId = student.TeachClass.Id;
                    studentDto.TeachClassName = student.TeachClass.Name;
                }
            }
            return studentDto;
        }
    }
}
