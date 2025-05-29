using MatriculaWeb.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MatriculaWeb.UI.Controllers
{
    public class GestionDeMatriculasController : Controller
    {
        // GET: GestionDeMatriculasController
        public async Task<ActionResult> Index()
        {
            //cliente para consumir api en web 
            var clientehttp = new HttpClient();
            List<Estudiante> listaEstudiantes;

            //request en api de forma asincrona
            var response = await clientehttp.GetAsync("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLaLista");
            //Response en JSON
            String respuestaDelApi = await response.Content.ReadAsStringAsync();

            listaEstudiantes = JsonConvert.DeserializeObject <List<Estudiante>> (respuestaDelApi);

            return View(listaEstudiantes);
        }

        // GET: GestionDeMatriculasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var clientehttp = new HttpClient();

            //uri?dictionary
            var query = new Dictionary<String, String>()
            {
                ["id"] = id.ToString()
            };

            var uri = QueryHelpers.AddQueryString("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaPorId", query);

            var response = await clientehttp.GetAsync(uri);
            String respuestaDelApi = await response.Content.ReadAsStringAsync();

            Estudiante estudiante = JsonConvert.DeserializeObject<Estudiante>(respuestaDelApi);


            return View(estudiante);
        }

        // GET: GestionDeMatriculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GestionDeMatriculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Estudiante estudiante)
        {
            try
            {

                var clientehttp = new HttpClient();

                EstudianteToApi _estudiante = new EstudianteToApi();
                _estudiante.Id = 0;
                _estudiante.Cedula= estudiante.Cedula;
                _estudiante.Nombre= estudiante.Nombre;
                _estudiante.PrimerApellido = estudiante.PrimerApellido;
                _estudiante.SegundoApellido = estudiante.SegundoApellido;
                _estudiante.Sexo = estudiante.Sexo;
                _estudiante.FechaDeNacimiento = estudiante.FechaDeNacimiento;
                _estudiante.Edad = "";
                _estudiante.CedulaMadre = estudiante.CedulaMadre;
                _estudiante.CedulaPadre= estudiante.CedulaPadre;
                
                

                string json = JsonConvert.SerializeObject(_estudiante);
                var byteContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await clientehttp.PostAsync("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/Registre", byteContent);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestionDeMatriculasController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var clientehttp = new HttpClient();

            //uri?dictionary
            var query = new Dictionary<String, String>()
            {
                ["id"] = id.ToString()
            };

            var uri = QueryHelpers.AddQueryString("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaPorId", query);

            var response = await clientehttp.GetAsync(uri);
            String respuestaDelApi = await response.Content.ReadAsStringAsync();

            Estudiante estudiante = JsonConvert.DeserializeObject<Estudiante>(respuestaDelApi);

            return View(estudiante);
        }

        // POST: GestionDeMatriculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Estudiante estudiante)
        {
            try
            {
                var clientehttp = new HttpClient();

                EstudianteToApi _estudiante = new EstudianteToApi();
                _estudiante.Id = estudiante.Id;
                _estudiante.Cedula = estudiante.Cedula;
                _estudiante.Nombre = estudiante.Nombre;
                _estudiante.PrimerApellido = estudiante.PrimerApellido;
                _estudiante.SegundoApellido = estudiante.SegundoApellido;
                _estudiante.Sexo = estudiante.Sexo;
                _estudiante.FechaDeNacimiento = estudiante.FechaDeNacimiento;
                _estudiante.Edad = "";
                _estudiante.CedulaMadre = estudiante.CedulaMadre;
                _estudiante.CedulaPadre = estudiante.CedulaPadre;



                string json = JsonConvert.SerializeObject(_estudiante);
                var byteContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await clientehttp.PutAsync("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/Edite", byteContent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Historial(int id)
        {
            var clientehttp = new HttpClient();

            //uri?dictionary
            var query = new Dictionary<String, String>()
            {
                ["id"] = id.ToString()
            };

            //GET FAMILY DATA
            var uri2 = QueryHelpers.AddQueryString("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/DevuelvaElDetalleFamiliar", query);
            var response2 = await clientehttp.GetAsync(uri2);
            String respuestaDelApi2 = await response2.Content.ReadAsStringAsync();
            HistorialFamiliar historial = JsonConvert.DeserializeObject<HistorialFamiliar>(respuestaDelApi2);

            //GET STUDENT
            var uri = QueryHelpers.AddQueryString("https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaPorId", query);
            var response = await clientehttp.GetAsync(uri);
            String respuestaDelApi = await response.Content.ReadAsStringAsync();
            Estudiante estudiante = JsonConvert.DeserializeObject<Estudiante>(respuestaDelApi);


            //SET VALUE
            estudiante.historialFamiliar = historial;


            return View(estudiante);
        }
    }
}
