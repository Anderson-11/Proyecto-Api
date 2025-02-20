using ApiRest.Models;
using ApiRest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoDao _produc = new ProductoDao();

        public ProductoController(ProductoDao dao) { 
            _produc = dao;
        }

        [HttpGet("Ver-Productos")]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            var product = _produc.SelectALL();
            if (product == null)
            {
                return NotFound("NO SE ENCONTRO NINGUN PRODUCTO");
            }
            return Ok(product);
        }

        [HttpGet("SeleccionarPorId/{id}")]
        public async Task<ActionResult<Producto>> idproduc(int id)
        {
            var leerproduc = _produc.GetById(id);
            if (leerproduc == null)
            {
                return NotFound($"No se encontro el Id {id}");
            }
            return Ok(leerproduc);
        }

        [HttpPost("Insertar-Productos")]
        public async Task<ActionResult<Producto>> InsertProduct([FromBody] Producto producto)
        {
            if (producto == null || string.IsNullOrWhiteSpace(producto.Nombre) || producto.Stock < 0 || producto.Precio <= 0)
            {
                return BadRequest("Los datos no cumplen con algunas restricciones");
            }

            var nuevoproducto = new Producto
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            var result = _produc.InsertProduct(nuevoproducto);
            if (result == null)
            {
                return StatusCode(500, "ERROR AL INSERTAR PRODUCTO");
            }

            return Ok(result);
        }

        [HttpPut("Actualizar-Productos")]
        public async Task<ActionResult<Producto>> UpdateProduct([FromBody] Producto producto)
        {
            var result = _produc.UpdateProduct(producto);
            if (!result)
            {
                return StatusCode(500, "ERROR AL ACTUALIZAR PRODUCTO");
            }

            return Ok(producto);
        }

        [HttpDelete("Eliminar-Producto")]
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                bool delete = _produc.DeleteProducts(id);
                if (delete)
                {
                    return Ok(new { mensaje = "'El Producto Fue Eliminado Con Exito'" });
                }
                else { return NotFound(new { mensaje = "No se encontro ningun producto" }); }
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "ERROR INTERNO", error = ex.Message });
            }
        }
    }
}
