namespace WebApiConcepts.A03._02.Dto.Services.ForUsersAndRoles
{
    public class UserDtoModelService : IUserDtoModelService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDomainRepository<Student> _studentRepository;

        public UserDtoModelService(IUserRepository userRepository, IDomainRepository<Student> studentRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository; 
        }

        public async Task<ApplicationUserDto> GetUserDtoAsync(Guid id)
        {
            var ddo = await _userRepository.GetUserAsync(id);
            var dto = DtoMapper.GetDto<ApplicationUser, ApplicationUserDto>(ddo);
            return dto;

        }
        
        public async Task<ApplicationUserDto> GetUserDtoAsync(string userName)
        {
            var ddo = await _userRepository.GetUserAsync(userName);
            var dto = DtoMapper.GetDto<ApplicationUser, ApplicationUserDto>(ddo);
            return dto;

        }
        
        public async Task<List<string>> GetUserRoleNameAsync(string userName)
        {
            return await _userRepository.GetUserRoleNameCollectionAsync(userName);
        }

        public async Task<DataPager<ApplicationUserDto>> GetUserDtoDataPager(Expression<Func<ApplicationUser, bool>> predicate, int pageIndex, int pageSize)
        {
            var ddoDataPager = await _userRepository.GetUsersDataPagerAsync(predicate, pageIndex, pageSize);
            var dtoDataPager = DtoMapper.GetDataPager<ApplicationUser, ApplicationUserDto>(ddoDataPager);
            return dtoDataPager;

        }

        public async Task<ApplicationUserForDisplayDto> GetUserForDisplayDtoAsync(Guid id)
        {
            var user  = await _userRepository.GetUserAsync(id);
            var result = new ApplicationUserForDisplayDto() { Id = user.Id, UserName = user.UserName };
            
            var student=await _studentRepository.GetAsync(x=>x.AppllicationUser!.Id == user.Id);
            if (student != null)
                result.PersonName = student.Name;
            return result;
        }

        public async Task<List<Claim>> GetUserClaimCollection(string userName)
        {
            return await _userRepository.GetUserClaimCollection(userName);
        }

        public async Task<List<string>> GetPermissionCollectionAsync(string userId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetPermissionCollectionAsync(userId, cancellationToken);
        }
    }
}
