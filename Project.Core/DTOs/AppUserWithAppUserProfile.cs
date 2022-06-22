namespace Project.Core.DTOs
{
    public class AppUserWithAppUserProfile : AppUserDto
    {
        public AppUserProfileDto Profile { get; set; }
    }
}
