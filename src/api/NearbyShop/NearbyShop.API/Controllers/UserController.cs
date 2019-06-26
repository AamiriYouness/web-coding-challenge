using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NearbyShop.API.Repositories;
using NearbyShop.API.ViewModels;
using System.Threading.Tasks;

namespace NearbyShop.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepository,
                              IMapper mapper,
                              IHttpContextAccessor httpContextAccessor,
                              UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            string userId = User.Identity.Name;
            var user = await _userManager.FindByIdAsync(userId);
            if (user== null)
                return BadRequest();
            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        [Route("shops")]
        public async Task<ActionResult<ShopViewModel[]>> GetPreferredShops()
        {
            string userId = User.Identity.Name;
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var results = await _userRepository.GetPreferredShopsAsync(userId);
            return _mapper.Map<ShopViewModel[]>(results);
        }

        [HttpPost]
        [Authorize]
        [Route("shops")]
        public async Task<IActionResult> AddShop(AddUSerShopViewModel model)
        {
            string userId = User.Identity.Name;
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var results = await _userRepository.AddPreferredShopAsync(model.Id, userId);
            return Ok(_mapper.Map<ShopViewModel[]>(results));
        }

        [HttpDelete]
        [Authorize]
        [Route("shops/{id:int}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            string userId = User.Identity.Name;
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var results = await _userRepository.RemovePreferredShopAsync(id, userId);
            return Ok(_mapper.Map<ShopViewModel[]>(results));
        }

    }
}
