using API_Productos.Data;
using API_Productos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Producto> products = await _db.Producto.ToListAsync();
            return Ok(products);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{IdProducto}")]
        public async Task<IActionResult> Get(int IdProducto)
        {
            Producto p= await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto== IdProducto);
            if (p == null)
            {
                return BadRequest();
            }
            return Ok(p);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto p)
        {
            Producto prod2 = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == p.IdProducto);
            if (prod2 == null && p!=null)
            {
                await _db.Producto.AddAsync(p);
                await _db.SaveChangesAsync();
                return Ok(p);
            }
            return BadRequest("El objeto ya existe");   
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{IdProducto}")]
        public async Task<IActionResult> Put(int IdProducto, [FromBody] Producto p)
        {
            Producto prod2 = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
            if (prod2 != null)
            {
                prod2.Nombre= p.Nombre != null ? p.Nombre : prod2.Nombre;
                prod2.Descripcion= p.Descripcion != null ? p.Descripcion : prod2.Descripcion;
                prod2.Cantidad= p.Cantidad != null ? p.Cantidad : prod2.Cantidad;
                _db.Producto.Update(prod2);
                await _db.SaveChangesAsync();
                return Ok(prod2);
            }
            return BadRequest("El Producto no existe");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{IdProducto}")]
        public async Task<IActionResult> Delete(int IdProducto)
        {
            Producto p = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
            if (p != null)
            {
                _db.Producto.Remove(p);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest("El objeto no existe");
        }
    }
}
