namespace Project.Core.DTOs
{
    public class AppUserWithAppUserProfile : AppUserDto
    {
        public AppUserDto Profile { get; set; }
    }
}
