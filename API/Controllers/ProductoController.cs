using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.ADO_Repository;
using API.Controllers.DTOS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
        [HttpDelete]
        public bool EliminarProducto([FromBody] int id)
        {
            return ProductoHandler.EliminarProducto(id);
        }
        [HttpPost]
        public bool CrearProducto([FromBody] PostProducto producto)
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario
            });
        }
        [HttpPut]
        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarProducto(new Producto
            {
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario
            });
        }
    }
}