using Microsoft.AspNetCore.Mvc;

using CreditCar.Entity.Models;
using CreditCar.Infrastructure.Services;
using CreditCar.Domain.Interfaces;

namespace CreditCar.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //private object servicio;

        private readonly IPost servicio;

        public BlogController(IPost _servicio){

           servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await servicio.GetPosts();
        }
        
    }
}