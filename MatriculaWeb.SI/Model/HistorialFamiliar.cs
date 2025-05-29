namespace MatriculaWeb.SI.Model
{
    public class HistorialFamiliar
    {
        public List<Estudiante> ListaDeHijos { get; set; }
        public List<Estudiante> ListaDePadres { get; set; }
        public List<Estudiante> ListaDeHermanos { get; set; }
        public List<Estudiante> ListaDeAbuelos { get; set; }
        public List<Estudiante> ListaDeTios { get; set; }
        public List<Estudiante> ListaDePrimos { get; set; }

        public HistorialFamiliar()
        {
            ListaDeHijos = new List<Estudiante>();
            ListaDePadres = new List<Estudiante>();
            ListaDeHermanos = new List<Estudiante>();
            ListaDeAbuelos = new List<Estudiante>();
            ListaDeTios = new List<Estudiante>();
            ListaDePrimos = new List<Estudiante>();
        }
    }

}
