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

        public async Task<CustomResponseDto<List<AppUserWithAppUserProfile>>> GetAppUsersWithAppUserProfile()
        {
            List<AppUser> appUsers = await _appUserRepository.GetAppUsersWithAppUserProfile();

            List<AppUserWithAppUserProfile> appUserDto = _mapper.Map<List<AppUserWithAppUserProfile>>(appUsers);

            return CustomResponseDto<List<AppUserWithAppUserProfile>>.Success(200, appUserDto);
            

        }
    }
}
