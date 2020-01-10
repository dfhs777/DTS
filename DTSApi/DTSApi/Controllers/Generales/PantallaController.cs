using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTSApi.Entitys;
using DTSApi.Models.Sql;
using DTSApi.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PantallaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PantallaController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Pantallas
        //obtiene listado de Pantallas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pantalla>>> Get()
        {
            return await _context.PantallaDbSet.Include(x => x.SecuenciaTipoPantalla).Include(x => x.SecuenciaEsquema).ToListAsync();
        }

        // GET: api/Pantallas/5
        [HttpGet("{id}", Name = "ObtenerPantalla")]
        public async Task<ActionResult<Pantalla>> GetId(int secuencia)
        {
            var claveP = await _context.PantallaDbSet.Include(x => x.SecuenciaTipoPantalla).Include(x => x.SecuenciaEsquema).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/PantallaSQL")]
        public async Task<ActionResult<IEnumerable<Pantalla>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Pantalla), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.PantallaDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.PantallaDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Pantallas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pantalla pantallas)
        {
            _context.PantallaDbSet.Add(pantallas);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPantalla", new { id = pantallas.Secuencia }, pantallas);
        }

        // PUT: api/Pantallas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Pantalla value)
        {
            if (secuencia != value.Secuencia)
            {
                return BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
