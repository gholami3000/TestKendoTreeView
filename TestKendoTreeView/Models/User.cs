namespace TestKendoTreeView.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UsreRole>();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UsreRole> UserRoles { get; set; }
    }
}
