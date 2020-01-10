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
    public class RolEsquemaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RolEsquemaController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/RolesEsquema
        //obtiene listado de RolesEsquema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolEsquema>>> Get()
        {
            return await _context.RolEsquemaDbSet.Include(x => x.SecuenciaEsquema).Include(x => x.SecuenciaPermiso).Include(x => x.SecuenciaRol).ToListAsync();
        }

        // GET: api/RolesEsquema/5
        [HttpGet("{id}", Name = "ObtenerRolEsquema")]
        public async Task<ActionResult<RolEsquema>> GetId(int secuencia)
        {
            var claveP = await _context.RolEsquemaDbSet.Include(x => x.SecuenciaEsquema).Include(x => x.SecuenciaPermiso).Include(x => x.SecuenciaRol).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/RolEsquemaSQL")]
        public async Task<ActionResult<IEnumerable<RolEsquema>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(RolEsquema), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.RolEsquemaDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.RolEsquemaDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/RolEsquema
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolEsquema rolesEsquema)
        {
            _context.RolEsquemaDbSet.Add(rolesEsquema);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerRolEsquema", new { id = rolesEsquema.Secuencia }, rolesEsquema);
        }

        // PUT: api/RolEsquema/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] RolEsquema value)
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
