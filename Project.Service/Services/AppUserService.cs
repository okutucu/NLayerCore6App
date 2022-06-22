using AutoMapper;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Repositories;
using Project.Core.Services;
using Project.Core.UnitOfWorks;

namespace Project.Service.Services
{
    public class AppUserService : Service<AppUser>, IAppUserService
    {

        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        public AppUserService(IGenericRepository<AppUser> repository, IUnitOfWork unitOfWork, IMapper mapper, IAppUserRepository appUserRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public async Task<CustomResponseDto<AppUserWithAppUserProfile>> GetAppUsersWithAppUserProfile(int appUserId)
        {
            AppUser appUser = await _appUserRepository.GetAppUsersWithAppUserProfile(appUserId);

            AppUserWithAppUserProfile appUserDto = _mapper.Map<AppUserWithAppUserProfile>(appUser);

            return CustomResponseDto<AppUserWithAppUserProfile>.Success(200, appUserDto);
            

        }
    }
}
