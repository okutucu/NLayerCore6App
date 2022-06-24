namespace Project.Core.Models
{
    public class AppUser : BaseEntity
    {

        public string UserName { get; set; }
        public string Password { get; set; }


        //Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; }
    }
}
