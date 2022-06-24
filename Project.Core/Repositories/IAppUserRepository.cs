using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {

        Task<List<AppUser>> GetAppUsersWithAppUserProfile();

    }
}
