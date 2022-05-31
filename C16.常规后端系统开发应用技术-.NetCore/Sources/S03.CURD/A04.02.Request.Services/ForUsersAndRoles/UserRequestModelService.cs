using DataCURD.A01.Shared.ExpressionExtensions;

namespace DataCURD.A04._02.Request.Services.ForUsersAndRoles
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

        public async Task<RequestProcessResult> AddUserAsync(ApplicationUserRegisterRequest request)
        {
            var result = new RequestProcessResult() { Success = false, Message = "数据存在错误，无法增加用户数据！", Result = null };
            // 检查是否已经存在用户
            var user = await _userRepository.GetUserAsync(request!.UserName!);
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                var op = await _userRepository.AddUserAsync(user, request.Password!);
                if (op)
                {
                    result.Success = true;
                    result.Message = "";
                    result.Result = user;
                }
            }
            else
            {
                result.Message = "提交的用户名已经存在，不能重复提交！";
            }
            return result;
        }

        public async Task<RequestProcessResult> UpdateUserAsync(ApplicationUserRequest request)
        {
            var result = new RequestProcessResult() { Success = false, Message = "数据存在错误，无法更新用户数据！", Result = null };
            var user = await _userRepository.GetUserAsync(request.Id);
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            var op = await _userRepository.UpdateUserAsync(user);
            if (op)
            {
                result.Success = true;
                result.Message = "";
                result.Result = user;
            }
            return result;

        }

        public async Task<RequestProcessResult> DeleteUserByIdAsync(Guid id)
        {
            var result = new RequestProcessResult() { Success = false, Message = "数据存在错误，无法删除用户数据！", Result = null };
            var op = await _userRepository.DeleteUserAsync(id);
            if (op)
            {
                result.Success = true;
                result.Message = "";
            }
            return result;
        }

        public async Task<bool> HasPermissionAsync(string userId, string permission) 
        {
            return await _userRepository.HasPermissionAsync(userId, permission);
        }

    }
}
