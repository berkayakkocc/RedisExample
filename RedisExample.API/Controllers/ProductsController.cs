using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisExample.API.Models;
using RedisExample.API.Repositories;
using RedisExample.API.Services;
using RedisExample.Cache;
using StackExchange.Redis;

namespace RedisExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices ;
        private readonly IDatabase _database;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productServices.GetAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productServices.GetByIdAsync(id));
        }
        
        [HttpPost]

        public async Task<IActionResult> Create(Product product)
        {
            return Created(string.Empty,await _productServices.CreateAsync(product));
        }
    }
}
