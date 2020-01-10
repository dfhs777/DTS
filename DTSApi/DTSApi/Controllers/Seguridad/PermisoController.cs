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
    public class PermisoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PermisoController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Permisos
        //obtiene listado de Permisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permiso>>> Get()
        {
            return await _context.PermisoDbSet.ToListAsync();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}", Name = "ObtenerPermisos")]
        public async Task<ActionResult<Permiso>> GetId(int secuencia)
        {
            var claveP = await _context.PermisoDbSet.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/PermisoSQL")]
        public async Task<ActionResult<IEnumerable<Permiso>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Permiso), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.PermisoDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.PermisoDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Permisos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Permiso permisos)
        {
            _context.PermisoDbSet.Add(permisos);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPermisos", new { id = permisos.Secuencia }, permisos);
        }

        // PUT: api/Permisos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Permiso value)
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
