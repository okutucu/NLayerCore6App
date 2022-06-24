namespace Project.Core.Models
{
    public class AppUserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AppUserId { get; set; }
        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
