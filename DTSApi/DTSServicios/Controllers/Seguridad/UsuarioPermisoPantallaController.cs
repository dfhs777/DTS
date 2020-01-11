using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DTSServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPermisoPantallaController : ControllerBase
    {
        // GET: api/UsuarioPermisoPantalla
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UsuarioPermisoPantalla/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UsuarioPermisoPantalla
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UsuarioPermisoPantalla/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
