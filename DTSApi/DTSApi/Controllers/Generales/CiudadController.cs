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

namespace DTSApi.Controllers.Generales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CiudadController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Ciudad
        //obtiene listado de Ciudad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
        {
            return await _context.CiudadDbSet.Include(x => x.SecuenciaEstado).ToListAsync();
        }

        // GET: api/Ciudad/5
        [HttpGet("{id}", Name = "ObtenerCiudad")]
        public async Task<ActionResult<Ciudad>> GetId(int secuencia)
        {
            var claveP = await _context.CiudadDbSet.Include(x => x.SecuenciaEstado).FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/EstadoSQL")]
        public async Task<ActionResult<IEnumerable<Ciudad>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Ciudad), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.CiudadDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.CiudadDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Ciudad
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ciudad ciudad)
        {
            _context.CiudadDbSet.Add(ciudad);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerCiudad", new { id = ciudad.Secuencia }, ciudad);
        }

        // PUT: api/Ciudad/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Ciudad value)
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
