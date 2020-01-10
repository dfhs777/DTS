using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTSApi.Entitys;
using DTSApi.Models.Sql;
using DTSApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DTSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsquemaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EsquemaController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Esquemas
        //obtiene listado de esquemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esquema>>> Get()
        {
            return await _context.EsquemaDbSet.ToListAsync();
        }

        // GET: api/Esquemas/5
        [HttpGet("{id}", Name = "ObtenerEsquema")]
        public async Task<ActionResult<Esquema>> GetId(int secuencia)
        {
            var claveP =await _context.EsquemaDbSet.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/EsquemasSQL")]
        public async Task<ActionResult<IEnumerable<Esquema>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Esquema), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.EsquemaDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.EsquemaDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);
            
        }

        // POST: api/Esquemas
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Esquema esquema)
        {
            _context.EsquemaDbSet.Add(esquema);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerEsquema", new { id = esquema.Secuencia }, esquema);
        }

        // PUT: api/Esquemas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Esquema value)
        {
            if (secuencia != value.Secuencia) {
                return BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
