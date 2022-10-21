namespace TestKendoTreeView.Models
{
    public class UsreRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User? Users { get; set; }
        public Role? Role { get; set; }
    }
}
