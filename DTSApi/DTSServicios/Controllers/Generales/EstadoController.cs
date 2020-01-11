using DTSServicios.Entitys;
using DTSServicios.Models.Sql;
using DTSServicios.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Controllers.Generales
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EstadoController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Estado
        //obtiene listado de Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            return await _context.EstadoDbSet.Include(x => x.SecuenciaPais).ToListAsync();
        }

        // GET: api/Estado/5
        [HttpGet("{id}", Name = "ObtenerEstado")]
        public async Task<ActionResult<Estado>> GetId(int secuencia)
        {
            var claveP = await _context.EstadoDbSet.Include(x => x.SecuenciaPais).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/EstadoSQL")]
        public async Task<ActionResult<IEnumerable<Estado>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Estado), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.EstadoDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.EstadoDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Estado
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estado estado)
        {
            _context.EstadoDbSet.Add(estado);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerEstado", new { id = estado.Secuencia }, estado);
        }

        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Estado value)
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
