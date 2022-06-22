using Microsoft.EntityFrameworkCore;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Project.Repository.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }

       

        public async Task<AppUser> GetAppUsersWithAppUserProfile(int appUserId)
        {
            return await _context.AppUsers.Include(x => x.AppUserProfile).Where(x => x.Id == appUserId).SingleOrDefaultAsync();
        }
    }
}
