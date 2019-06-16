using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NearbyShop.API.Repositories;
using NearbyShop.API.ViewModels;
using System;
using System.Threading.Tasks;

namespace NearbyShop.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopsController(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ShopViewModel[]>> GetAll()
        {
            try
            {
                var results = await _shopRepository.GetAllShopsAsync();
                return _mapper.Map<ShopViewModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
