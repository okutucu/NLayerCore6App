using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.Models;
using Project.Core.Services;

namespace Project.API.Controllers
{

    public class AppUserController : CustomBaseController
    {

        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        // GET api/appuser//GetAppUsersWithAppUserProfile/2
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAppUsersWithAppUserProfile(int appUserId)
        {
            return CreateActionResult(await _appUserService.GetAppUsersWithAppUserProfile(appUserId));
        }



        // GET  api/AppUsers
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AppUser> appUsers = await _appUserService.GetAllAsync();

            List<AppUserDto> appUsersDto = _mapper.Map<List<AppUserDto>>(appUsers.ToList());

            return CreateActionResult(CustomResponseDto<List<AppUserDto>>.Success(200, appUsersDto));


        }
    }
}
