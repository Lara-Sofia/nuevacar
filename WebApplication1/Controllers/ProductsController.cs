using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application;
using Web.Application.IServices;
using Web.Application.Services;
using Web.Domain.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductoServices _productoServices;
        public ProductsController(IProductoServices prodServices)
        {
            _productoServices = prodServices;
        }

        [HttpPost("Create")]
        public IActionResult Createproduct([FromBody]Producto producto)
        {
            //var created = _prodcutServices.CreateProduct(producto);
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string apiAndEndpointUrl = $"api/Producto/GetById";
            string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{producto.Id}";

            return Created(locationUrl, producto);
        }


        [HttpGet("All")]
        public ActionResult<IEnumerable<Producto?>>GetAll()
        {
            var response = _productoServices.GetProductList();

            if (!response.Any())
            {
                return NotFound("No se encontraron recursos en la base de datos");
            }

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Producto?> GetById([FromRoute]int id)
        {
            var producto = _productoServices.GetById(id);
            return Ok(producto);
        }

        [HttpPut]
        public IActionResult Update(Producto? producto) 
        {
            return Ok(_productoServices.UpdateProduct(producto));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute]int id) 
        {
            if (id == null)
            {
                return BadRequest("No existe");
            }
            return Ok(_productoServices.DeleteProduct(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] DtoProducto body)
        {
            return Ok(_productoServices.AddUser(body));
        }


    }
}
