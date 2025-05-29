using MatriculaWeb.SI.Model;

namespace MatriculaWeb.SI.Logic
{
    public interface IRepositorioEstudiantes
    {
        //CRUD
        void Registre(Estudiante estudiante);
        List<Estudiante> ObtengaLaLista();
        void Edite(Estudiante estudiante);

        //functions
        Estudiante ObtengaPorId(int id);
        HistorialFamiliar DevuelvaElDetalleFamiliar(int id);
        List<Estudiante> ObtengaLasFemeninas();
        List<Estudiante> ObtengaLosMasculinos();

    }
}
