using Microsoft.AspNetCore.Mvc;
using Cine_API.Models;

namespace Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // GET: api/<PedidosController>
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            // Implement your logic to retrieve the list of Pedidos from the database
            // For now, I am returning an empty list as an example
            return new List<Pedido>();
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            // Implement your logic to retrieve a single Pedido with the given id from the database
            // For now, I am returning a dummy Pedido object as an example
            return new Pedido();
        }

        // POST api/<PedidosController>
        [HttpPost]
        public void Post([FromBody] Pedido pedido)
        {
            // Implement your logic to create a new Pedido using the data from the request body (pedido)
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pedido pedido)
        {
            // Implement your logic to update the existing Pedido with the given id using the data from the request body (pedido)
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Implement your logic to delete the Pedido with the given id from the database
        }
    }
}
