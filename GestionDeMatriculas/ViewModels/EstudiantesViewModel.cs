using GestionDeMatriculas.Logic;
using GestionDeMatriculas.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMatriculas.ViewModels
{
    public class EstudiantesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Model.Estudiante> estudiantes;

        public List<Estudiante> Estudiantes
        {
            get { return estudiantes; }
            set
            {
                if (estudiantes != value)
                {
                    estudiantes = value;
                    OnPropertyChanged(nameof(Estudiantes));
                }
            }
        }

        public async Task ObtenerEstudiantesAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLaLista";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
                }
                else
                {
                    // Manejo de error si la respuesta no es exitosa
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de excepción
            }
        }
        public async Task ObtenerEstudiantesFemeninosAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLasFemeninas";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
                }
                else
                {
                    // Manejo de error si la respuesta no es exitosa
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de excepción
            }
        }
        public async Task ObtenerEstudiantesMasculinosAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "https://apiserviceexamen.azurewebsites.net/api/GestionDeMatriculas/ObtengaLosMasculinos";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
                }
                else
                {
                    // Manejo de error si la respuesta no es exitosa
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de excepción
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
