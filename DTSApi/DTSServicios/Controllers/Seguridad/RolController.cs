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
    public class RolController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RolController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Rol
        //obtiene listado de Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> Get()
        {
            return await _context.RolDbSet.ToListAsync();
        }

        // GET: api/Rol/5
        [HttpGet("{id}", Name = "ObtenerRol")]
        public async Task<ActionResult<Rol>> GetId(int secuencia)
        {
            var claveP = await _context.RolDbSet.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/RolSQL")]
        public async Task<ActionResult<IEnumerable<Rol>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Rol), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.RolDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.RolDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Rol
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol rol)
        {
            _context.RolDbSet.Add(rol);
            await _context.SaveChangesAsync();
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
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
