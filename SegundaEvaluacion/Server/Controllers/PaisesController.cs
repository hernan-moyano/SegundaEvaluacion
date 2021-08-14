using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundaEvaluacion.Shared.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaEvaluacion.Server.Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class PaisesController : ControllerBase
    {
        private readonly dbContext context;

        public PaisesController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Pais>>> Get()
        {
            return await context.Paises.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pais>> Get(int id)

        {
            var Pais = await context.Paises.Where(X => X.Id == id).FirstOrDefaultAsync();
            if (Pais == null)

            {
                return NotFound($"no existe el Pais con id igual a { id}.");
            }
            return Ok(Pais);
        }


        [HttpPost]
        public async Task<ActionResult<Pais>> Post(Pais pais)
        {

            try
            {
                context.Paises.Add(pais);
                await context.SaveChangesAsync();

                return pais;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest("Datos Erroneos");
            }

            var error = await context.Paises.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (error == null)
            {
                return NotFound("No existe el pais a modificar");
            }

            error.CodPais = pais.CodPais;
            error.NombrePais = pais.NombrePais;

            try
            {
                context.Paises.Update(error);
                await context.SaveChangesAsync();

                return Ok("Los datos fueron cambiados.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Pais pais = await context.Paises.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pais == null)
            {
                return NotFound($"No se encontro el pais con id igual a {id}");
            }

            try
            {
                context.Paises.Remove(pais);
                await context.SaveChangesAsync();

                return Ok($"El pais {pais.NombrePais} ah sido borrado.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
