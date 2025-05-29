using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestionDeMatriculas.Logic
{
    public class EstudiantesService
    {
        private HttpClient httpClient;

        public EstudiantesService()
        {
            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Model.Estudiante>> ObtenerEstudiantesAsync()
        {
            var url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLaLista";

            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var estudiantes = JsonConvert.DeserializeObject<ObservableCollection<Model.Estudiante>>(content);
                    return estudiantes;
                }
                else
                {
                    // Manejar el escenario de respuesta no exitosa de la API
                }
            }
            catch (HttpRequestException)
            {
                // Manejar cualquier excepción relacionada con la solicitud HTTP aquí
            }

            return new ObservableCollection<Model.Estudiante>();
        }
        public async Task<ObservableCollection<Model.Estudiante>> ObtenerEstudiantesFemeninosAsync()
        {
            var url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLasFemeninas";

            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var estudiantes = JsonConvert.DeserializeObject<ObservableCollection<Model.Estudiante>>(content);
                    return estudiantes;
                }
                else
                {
                    // Manejar el escenario de respuesta no exitosa de la API
                }
            }
            catch (HttpRequestException)
            {
                // Manejar cualquier excepción relacionada con la solicitud HTTP aquí
            }

            return new ObservableCollection<Model.Estudiante>();
        }
        public async Task<ObservableCollection<Model.Estudiante>> ObtenerEstudiantesMasculinosAsync()
        {
            var url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLosMasculinos";

            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var estudiantes = JsonConvert.DeserializeObject<ObservableCollection<Model.Estudiante>>(content);
                    return estudiantes;
                }
                else
                {
                    // Manejar el escenario de respuesta no exitosa de la API
                }
            }
            catch (HttpRequestException)
            {
                // Manejar cualquier excepción relacionada con la solicitud HTTP aquí
            }

            return new ObservableCollection<Model.Estudiante>();
        }
    }
}
