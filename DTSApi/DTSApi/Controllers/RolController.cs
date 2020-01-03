using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTSApi.Entitys;
using DTSApi.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DatabaseContext context;

        public RolController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/Rol
        //obtiene listado de Rol
        [HttpGet]
        public ActionResult<IEnumerable<Rol>> Get()
        {
            return context.Rol.ToList();
        }

        // GET: api/Rol/5
        [HttpGet("{id}", Name = "ObtenerRol")]
        public async Task<ActionResult<Rol>> GetId(int secuencia)
        {
            var claveP = await context.Rol.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol rol)
        {
            context.Rol.Add(rol);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerRol", new { id = rol.Secuencia }, rol);
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Rol value)
        {
            if (secuencia != value.Secuencia)
            {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
