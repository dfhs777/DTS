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
    public class RolesEsquemaController : ControllerBase
    {
        private readonly DatabaseContext context;

        public RolesEsquemaController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/RolesEsquema
        //obtiene listado de RolesEsquema
        [HttpGet]
        public ActionResult<IEnumerable<RolesEsquema>> Get()
        {
            return context.RolesEsquema.Include(x => x.SecuenciaEsquemas).Include(x => x.SecuenciaPermiso).Include(x => x.SecuenciaRol).ToList();
        }

        // GET: api/RolesEsquema/5
        [HttpGet("{id}", Name = "ObtenerRolesEsquema")]
        public async Task<ActionResult<RolesEsquema>> GetId(int secuencia)
        {
            var claveP = await context.RolesEsquema.Include(x => x.SecuenciaEsquemas).Include(x => x.SecuenciaPermiso).Include(x => x.SecuenciaRol).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/Pantallas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolesEsquema rolesEsquema)
        {
            context.RolesEsquema.Add(rolesEsquema);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerRolesEsquema", new { id = rolesEsquema.Secuencia }, rolesEsquema);
        }

        // PUT: api/Pantallas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] RolesEsquema value)
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
