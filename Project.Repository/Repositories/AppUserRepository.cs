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

       

        public async Task<List<AppUser>> GetAppUsersWithAppUserProfile()
        {
            return await _context.AppUsers.Include(x => x.AppUserProfile).ToListAsync();
        }
    }
}
