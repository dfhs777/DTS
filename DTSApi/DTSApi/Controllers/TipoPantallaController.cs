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
    public class TipoPantallaController : ControllerBase
    {
        private readonly DatabaseContext context;

        public TipoPantallaController(DatabaseContext context)
        {
            this.context = context;
        }
        // GET: api/TipoPantalla
        //obtiene listado de TipoPantalla
        [HttpGet]
        public ActionResult<IEnumerable<TipoPantalla>> Get()
        {
            return context.TipoPantalla.ToList();
        }

        // GET: api/TipoPantalla/5
        [HttpGet("{id}", Name = "ObtenerTipoPantalla")]
        public async Task<ActionResult<TipoPantalla>> GetId(int secuencia)
        {
            var claveP = await context.TipoPantalla.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        // POST: api/TipoPantalla
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoPantalla tipoPantalla)
        {
            context.TipoPantalla.Add(tipoPantalla);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerTipoPantalla", new { id = tipoPantalla.Secuencia }, tipoPantalla);
        }

        // PUT: api/TipoPantalla/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] TipoPantalla value)
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
