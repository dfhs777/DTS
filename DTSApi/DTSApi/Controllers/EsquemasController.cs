using System.Collections.Generic;
using System.Linq;
using DTSApi.Entitys;
using DTSApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DTSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsquemasController : ControllerBase
    {
        private readonly DatabaseContext context;

        public EsquemasController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/Esquemas
        //obtiene listado de esquemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esquemas>>> Get()
        {
            return await context.Esquemas.Include(x => x.Pantallas).Include(x => x.RolesEsquemas).ToList();
        }

        // GET: api/Esquemas/5
        [HttpGet("{id}", Name = "ObtenerEsquema")]
        public async Task<ActionResult<Esquemas>> GetId(int secuencia)
        {
            var claveP =await context.Esquemas.Include(x => x.Pantallas).Include(x=>x.RolesEsquemas).FirstOrDefaultAsync(x=>x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/Esquemas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Esquemas esquema)
        {
            context.Esquemas.Add(esquema);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerEsquema", new { id = esquema.Secuencia }, esquema);
        }

        // PUT: api/Esquemas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Esquemas value)
        {
            if (secuencia != value.Secuencia) {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
