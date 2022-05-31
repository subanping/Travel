using DataCURD.A04._02.Request.Services.Helpers;

namespace DataCURD.A04._02.Request.Services.Extenssiones.OrganizationBussiness
{
    public static class StudentCreateRequestExtenssion
    {
        public static async Task<bool> AddAndCreateUserAsync(
            this IRequestModelService<Student, StudentCreateRequest> service,
            IDomainRepository<Student> studentRepository,
            IUserRepository userRepository,
            StudentCreateRequest request)
        {
            // 处理学生关联用户的创建，作为一个简单用户数据，这里可以直接从请求数据中，获取足够的创建
            // 用户对象的数据，无需再通过映射器处理
            var user = new ApplicationUser();
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            await userRepository.AddUserAsync(user, request!.Password!);

            var ddo = new Student();
            await RequestMapper.SetDomainObject(ddo, request, studentRepository);
            ddo.AppllicationUser = user;

            return await studentRepository.AddAsync(ddo);
        }
    }
}
