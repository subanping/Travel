namespace WebApiConcepts.A02._01.Domain.Models.Application.UsersAndRoles
{
    public class ApplicationRole : IdentityRole<Guid>, IDataBase
    {
        public string? Description { get; set; }

        public ApplicationRole() { }

        public ApplicationRole(string name, string? description = null)
            : base(name)
        {
            Id = Guid.NewGuid();
            Description = description;
            NormalizedName = name.ToUpperInvariant();
        }
    }
}
