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
    public class PantallasController : ControllerBase
    {
        private readonly DatabaseContext context;

        public PantallasController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/Pantallas
        //obtiene listado de Pantallas
        [HttpGet]
        public  ActionResult<IEnumerable<Pantallas>> Get()
        {
            return context.Pantallas.Include(x => x.SecuenciaTipoPantalla).Include(x => x.SecuenciaEsquemas).ToList();
        }

        // GET: api/Pantallas/5
        [HttpGet("{id}", Name = "ObtenerPantalla")]
        public async Task<ActionResult<Pantallas>> GetId(int secuencia)
        {
            var claveP = await context.Pantallas.Include(x => x.SecuenciaTipoPantalla).Include(x => x.SecuenciaEsquemas).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/Pantallas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pantallas pantallas)
        {
            context.Pantallas.Add(pantallas);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPantalla", new { id = pantallas.Secuencia }, pantallas);
        }

        // PUT: api/Pantallas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Pantallas value)
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
