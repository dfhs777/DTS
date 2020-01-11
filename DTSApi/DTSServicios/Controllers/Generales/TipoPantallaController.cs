using DTSServicios.Entitys;
using DTSServicios.Models.Sql;
using DTSServicios.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPantallaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TipoPantallaController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/TipoPantalla
        //obtiene listado de TipoPantalla
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPantalla>>> Get()
        {
            return await _context.TipoPantallaDbSet.ToListAsync();
        }

        // GET: api/TipoPantalla/5
        [HttpGet("{id}", Name = "ObtenerTipoPantalla")]
        public async Task<ActionResult<TipoPantalla>> GetId(int secuencia)
        {
            var claveP = await _context.TipoPantallaDbSet.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/TipoPantallaSQL")]
        public async Task<ActionResult<IEnumerable<TipoPantalla>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(TipoPantalla), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.TipoPantallaDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.TipoPantallaDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/TipoPantalla
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoPantalla tipoPantalla)
        {
            _context.TipoPantallaDbSet.Add(tipoPantalla);
            await _context.SaveChangesAsync();
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
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
