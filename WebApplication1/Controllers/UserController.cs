using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.IServices;
using Web.Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]User user) 
        {
            var u = _userServices.CreateUser(user);
            if (!u)
            {
                return BadRequest("No me estoy creando");
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/Producto/GetById";
            string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{user.Id}";

            return Created(locationUrl, user);
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<User?>> GetAll()
        {
            return Ok(_userServices.GetUserList().ToList());
        }

        [HttpGet("GetById/{id}")]
        public  ActionResult<User?> GetById([FromRoute]int id)
        {
            return Ok(_userServices.GetUserById(id));
        }

        [HttpPut("Update")]
        public ActionResult<User?> Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("No hay data");
            }
            return Ok(_userServices.UpdateUser(user));//la lógica está en repository
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var prueba = _userServices.deleteUser(id);

            if (!prueba)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
