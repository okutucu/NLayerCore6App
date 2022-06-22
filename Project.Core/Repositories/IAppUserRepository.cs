using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {

        Task<AppUser> GetAppUsersWithAppUserProfile(int appUserId);
        
    }
}
