using MatriculaWeb.SI.Context;
using MatriculaWeb.SI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculaWeb.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionDeMatriculasController : ControllerBase
    {
        private Context.DbMatriculas Conexion;
        private Logic.RepositorioDeEstudiantes RepositorioDeEstudiantes; 

        public GestionDeMatriculasController(DbMatriculas conexion) 
        {
            RepositorioDeEstudiantes = new Logic.RepositorioDeEstudiantes(conexion);
        }


        //GET
        [HttpGet("ObtengaLaLista")]
        public List<Estudiante> ObtengaLaLista() 
        {
            return RepositorioDeEstudiantes.ObtengaLaLista();
        }
        //GET
        [HttpGet("ObtengaLasFemeninas")]
        public List<Estudiante> ObtengaLasFemeninas() 
        {
            return RepositorioDeEstudiantes.ObtengaLasFemeninas();
        }
        
        //GET
        [HttpGet("ObtengaLosMasculinos")]
        public List<Estudiante> ObtengaLosMasculinos() 
        {
            return RepositorioDeEstudiantes.ObtengaLosMasculinos();
        }

        //GET
        [HttpGet("ObtengaPorId")]
        public Estudiante ObtengaPorId(int id) 
        {
            return RepositorioDeEstudiantes.ObtengaPorId(id);
        }

        //GET
        [HttpGet("DevuelvaElDetalleFamiliar")]
        public HistorialFamiliar DevuelvaElDetalleFamiliar(int id) 
        {
            HistorialFamiliar h = RepositorioDeEstudiantes.DevuelvaElDetalleFamiliar(id);


            return h;
        }


        //POST
        [HttpPost("Registre")]
        public IActionResult Registre([FromBody]Estudiante estudiante) 
        {
            RepositorioDeEstudiantes.Registre(estudiante);
            return Ok();
        }

        //PUT
        [HttpPut("Edite")]
        public IActionResult Edite([FromBody]Estudiante estudiante) 
        {
            if (ModelState.IsValid)
            {
                RepositorioDeEstudiantes.Edite(estudiante);
                return Ok(estudiante);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
