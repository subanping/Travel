namespace Lp.OnlineLearning.Domain.Models.Application.UsersAndRoles
{
    public class ApplicationRole : IdentityRole<Guid>, IDataBase
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid();
        }
    }
}
