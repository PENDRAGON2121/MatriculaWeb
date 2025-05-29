using MatriculaWeb.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MatriculaWeb.UI.Controllers
{
    public class EstudiantesMasculinosController : Controller
    {
        // GET: EstudiantesMasculinosController
        public async Task<ActionResult> Index()
        {
            //cliente para consumir api en web 
            var clientehttp = new HttpClient();
            List<Estudiante> listaEstudiantes;

            //request en api de forma asincrona
            var response = await clientehttp.GetAsync("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLosMasculinos");
            //Response en JSON
            String respuestaDelApi = await response.Content.ReadAsStringAsync();

            listaEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(respuestaDelApi);

            return View(listaEstudiantes);
        }

       
    }
}
