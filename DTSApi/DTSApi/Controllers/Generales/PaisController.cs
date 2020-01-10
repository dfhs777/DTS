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
    public class PaisController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PaisController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/Pais
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            return await _context.PaisDbSet.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}", Name = "ObtenerPais")]
        public async Task<ActionResult<Pais>> GetId(int secuencia)
        {
            var claveP = await _context.PaisDbSet.FirstOrDefaultAsync(x => x.Secuencia == secuencia);
            if (claveP == null)
            {
                return NotFound();
            }
            return claveP;
        }

        [HttpGet("/api/PaisSQL")]
        public async Task<ActionResult<IEnumerable<Pais>>> PutEsquemasSqlSentence(SentenciaSql sentencia)
        {

            sentencia = ExtraUtils.GenerarSqlSelect(typeof(Pais), sentencia, _context);

            if (sentencia.Parametros == null || sentencia.Parametros.Length == 0)
                return await _context.PaisDbSet.FromSqlRaw(sentencia.Sentencia).ToListAsync().ConfigureAwait(true);
            else
                return await _context.PaisDbSet.FromSqlRaw(sentencia.Sentencia, ExtraUtils.ConvertirAParamPostgres(sentencia.Parametros.ToList()).ToArray()).ToListAsync().ConfigureAwait(true);

        }

        // POST: api/Pais
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pais pais)
        {
            _context.PaisDbSet.Add(pais);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObtenerPais", new { id = pais.Secuencia }, pais);
        }

        // PUT: api/Pais/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int secuencia, [FromBody] Pais value)
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
