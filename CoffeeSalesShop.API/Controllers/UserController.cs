using CoffeeSalesShop.API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeSalesShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() {}

        [HttpGet("GetUserById/{id:int}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            return Ok(new User());
        }
    }
}