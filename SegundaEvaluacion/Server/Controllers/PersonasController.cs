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
    [Route("api/Personas")]
    public class PersonasController : ControllerBase
    {
        private readonly dbContext context;


        public PersonasController(dbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.Include(x => x.Nacionalidad).ToListAsync();

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Persona>> Get(int id)
        {

            var Personas = await context.Personas.Where(X => X.Id == id).FirstOrDefaultAsync();

            if (Personas == null)
            {
                return NotFound($"no existe la Persona con id igual a {id}.");
            }

            return Personas;
        }

        [HttpPost]

        public async Task<ActionResult<Persona>> Post(Persona Personas)
        {
            try
            {
                context.Personas.Add(Personas);
                await context.SaveChangesAsync();
                return Personas;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [HttpPut("{id:int}")]

        public async Task<ActionResult<Persona>> Put(int id, [FromBody] Persona Personas)
        {
            if (id != Personas.Id)
            {
                return BadRequest("datos incorrectos");
            }


            var na = await context.Personas.Where(X => X.Id == id).FirstOrDefaultAsync();
            na.nombre = Personas.nombre;
            na.apellido = Personas.apellido;
            na.fecha_nacimiento = Personas.fecha_nacimiento;

            if (na == null)
            {
                return NotFound($"no existe la Persona a modificar.");
            }
            try
            {
                context.Personas.Update(na);
                await context.SaveChangesAsync();
                return Ok("los datos han sido cambiados");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var Personas = await context.Personas.Where(X => X.Id == id).FirstOrDefaultAsync();

            if (Personas == null)
            {
                return NotFound($"no existe la Persona con id igual a {id}.");
            }

            try
            {
                context.Personas.Remove(Personas);
                await context.SaveChangesAsync();
                return Ok($"la Persona {Personas.nombre} {Personas.apellido} ha sido borrada");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }

}
