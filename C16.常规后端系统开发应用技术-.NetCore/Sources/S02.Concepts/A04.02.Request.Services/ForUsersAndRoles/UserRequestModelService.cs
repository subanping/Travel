using WebApiConcepts.A01.Shared.ExpressionExtensions;
using WebApiConcepts.A04._02.Request.Services.Helpers;

namespace WebApiConcepts.A04._02.Request.Services.ForUsersAndRoles
{
    public class UserRequestModelService: IUserRequestModelService
    {
        private readonly IUserRepository _userRepository;

        public UserRequestModelService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Expression<Func<ApplicationUser, bool>> GetUserSearchPredicat(ISearchRequest searchRequest)
        {
            Expression<Func<ApplicationUser, bool>>? predicate = ExpressionExtension.GetConditionExpression<ApplicationUser>("");
            if (!string.IsNullOrEmpty(searchRequest.Name))
                predicate = ExpressionExtension.GetConditionExpression<ApplicationUser>(searchRequest.Name);
            return predicate!;
        }

        public async Task<bool> AddUserAsync(ApplicationUserRegisterRequest request)
        {
            var user = new ApplicationUser();
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            return await _userRepository.AddUserAsync(user,request.Password!);

        }

        public async Task<bool> UpdateUserAsync(ApplicationUserRequest request)
        {
            var user = await _userRepository.GetUserAsync(request.Id);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserByIdAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<bool> HasPermissionAsync(string userId, string permission) 
        {
            return await _userRepository.HasPermissionAsync(userId, permission);
        }

    }
}
