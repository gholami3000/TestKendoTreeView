namespace TestKendoTreeView.Models
{
    public class RoleClaim
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Role? Roles { get; set; }
    }
}
