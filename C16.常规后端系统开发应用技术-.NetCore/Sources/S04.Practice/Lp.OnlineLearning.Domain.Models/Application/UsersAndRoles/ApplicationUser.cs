namespace Lp.OnlineLearning.Domain.Models.Application.UsersAndRoles
{
    public class ApplicationUser : IdentityUser<Guid>, IDataBase
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }
    }
}
