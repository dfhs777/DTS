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
    public class PermisosController : ControllerBase
    {
        private readonly DatabaseContext context;

        public PermisosController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/Permisos
        //obtiene listado de Permisos
        [HttpGet]
        public ActionResult<IEnumerable<Permisos>> Get()
        {
            return context.Permisos.ToList();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}", Name = "ObtenerPermisos")]
        public async Task<ActionResult<Permisos>> GetId(int secuencia)
        {
            var claveP = await context.Permisos.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/Permisos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Permisos permisos)
        {
            context.Permisos.Add(permisos);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPermisos", new { id = permisos.Secuencia }, permisos);
        }

        // PUT: api/Permisos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Permisos value)
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
