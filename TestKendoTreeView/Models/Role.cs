namespace TestKendoTreeView.Models
{
    public class Role
    {

        public Role()
        {
            UserRoles = new HashSet<UsreRole>();   
            RoleClaims = new HashSet<RoleClaim>();   
        }

        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UsreRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }

    }
}
