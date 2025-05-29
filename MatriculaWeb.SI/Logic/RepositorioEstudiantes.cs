using MatriculaWeb.SI.Context;
using MatriculaWeb.SI.Model;

namespace MatriculaWeb.SI.Logic
{
    public class RepositorioDeEstudiantes : IRepositorioEstudiantes
    {
        private DbMatriculas Contexto;
        public RepositorioDeEstudiantes(DbMatriculas contexto)
        {
            Contexto = contexto;

        }

        public List<Estudiante> ObtengaLaLista()
        {
            List<Estudiante> estudiantes = Contexto.Estudiantes.ToList();
            foreach (var estudiante in estudiantes)
            {
                DateTime fechaDeNacimiento = estudiante.FechaDeNacimiento;
                int edad = DateTime.Today.Year - fechaDeNacimiento.Year;
                if (DateTime.Today < fechaDeNacimiento.AddYears(edad))
                {
                    edad--;
                }
                estudiante.Edad = edad.ToString();
            }
            return estudiantes;
        }

        public void Registre(Estudiante estudiante)
        {
            Contexto.Add(estudiante);
            Contexto.SaveChanges();

        }
        public void Edite(Estudiante estudiante)
        {
            Contexto.Update(estudiante);
            Contexto.SaveChanges();
        }

        public HistorialFamiliar DevuelvaElDetalleFamiliar(int id)
        {
            Estudiante estudiante = ObtengaPorId(id);
            HistorialFamiliar historial = new HistorialFamiliar();

            List<Estudiante> listaHijos = ObtengaLosRegistrosDeHijos(estudiante);
            List<Estudiante> listaDePadres = ObtengaLosRegistrosDeLosPadres(estudiante);
            List<Estudiante> listaAbuelos = ObtengaLosRegistrosDeLosAbuelos(estudiante);
            List<Estudiante> listaHermanos = ObtengaLosRegistrosDeLosHermanos(estudiante);
            List<Estudiante> listaTios = ObtengaLosRegistrosDeLosTios(estudiante);
            List<Estudiante> listaPrimos = ObtengaLosRegistrosDeLosPrimos(estudiante);


            historial.ListaDeHijos = listaHijos;
            historial.ListaDePadres = listaDePadres;
            historial.ListaDeAbuelos = listaAbuelos;
            historial.ListaDeHermanos = listaHermanos;
            historial.ListaDeTios = listaTios;
            historial.ListaDePrimos = listaPrimos;



            return historial;
        }
        private List<Estudiante> ObtengaLosRegistrosDeHijos(Estudiante estudiante)
        {
            Sexo sexo = estudiante.Sexo;

            if (sexo == Sexo.Masculino)
            {
                var listaDeHijos = from item in Contexto.Estudiantes
                                   where item.CedulaPadre == estudiante.Cedula
                                   select item;
                return (List<Estudiante>)listaDeHijos.ToList();
            }
            else
            {
                var listaDeHijos = from item in Contexto.Estudiantes
                                   where item.CedulaMadre == estudiante.Cedula
                                   select item;
                return (List<Estudiante>)listaDeHijos.ToList();
            }

        }
        private List<Estudiante> ObtengaLosRegistrosDeLosPadres(Estudiante estudiante)
        {

            var listaDePadre = from item in Contexto.Estudiantes
                               where item.Cedula == estudiante.CedulaPadre
                               select item;
            var listaDeMadre = from item in Contexto.Estudiantes
                               where item.Cedula == estudiante.CedulaMadre
                               select item;

            var listaDePadres = listaDePadre.Concat(listaDeMadre);



            return (List<Estudiante>)listaDePadres.ToList();
        }
        private List<Estudiante> ObtengaLosRegistrosDeLosHermanos(Estudiante estudiante)
        {

            var listaDeHermanos = from item in Contexto.Estudiantes
                                  where (item.CedulaPadre == estudiante.CedulaPadre || item.CedulaMadre == estudiante.CedulaMadre) && item.Cedula != estudiante.Cedula
                                  select item;

            return (List<Estudiante>)listaDeHermanos.ToList();
        }
        private List<Estudiante> ObtengaLosRegistrosDeLosTios(Estudiante estudiante)
        {

            var TiosPaternos = (from item in Contexto.Estudiantes
                                where item.CedulaPadre == (Contexto.Estudiantes
                                                            .Where(est => est.Cedula == estudiante.CedulaPadre)
                                                            .Select(est => est.CedulaPadre)
                                                            .FirstOrDefault())
                                      && item.Cedula != estudiante.CedulaPadre
                                select item).ToList();


            var TiosMaternos = (from item in Contexto.Estudiantes
                                where item.CedulaMadre == (Contexto.Estudiantes
                                                            .Where(est => est.Cedula == estudiante.CedulaMadre)
                                                            .Select(est => est.CedulaMadre)
                                                            .FirstOrDefault())
                                      && item.Cedula != estudiante.CedulaMadre
                                select item).ToList();

            var listaDeTios = TiosPaternos.Concat(TiosMaternos).ToList();


            return (List<Estudiante>)listaDeTios.ToList();
        }
        private List<Estudiante> ObtengaLosRegistrosDeLosPrimos(Estudiante estudianteActual)
        {

            var listaDeTios = ObtengaLosRegistrosDeLosTios(estudianteActual);

            var primos = new List<Estudiante>();

            foreach (var tio in listaDeTios)
            {
                var hijosTio = (from estudiante in Contexto.Estudiantes
                                where estudiante.CedulaPadre == tio.Cedula
                                      || estudiante.CedulaMadre == tio.Cedula
                                      && estudiante.Cedula != estudianteActual.Cedula
                                select estudiante).ToList();

                primos.AddRange(hijosTio);
            }

            return (List<Estudiante>)primos.ToList();
        }

        private List<Estudiante> ObtengaLosRegistrosDeLosAbuelos(Estudiante estudiante)
        {


            var abueloPorPadre = (from padre in Contexto.Estudiantes
                                  join abueloPaterno in Contexto.Estudiantes on padre.CedulaPadre equals abueloPaterno.Cedula
                                  where padre.Cedula == estudiante.CedulaPadre
                                  select abueloPaterno).ToList();

            var abueloPorMadre = (from padre in Contexto.Estudiantes
                                  join abueloPaterno in Contexto.Estudiantes on padre.CedulaPadre equals abueloPaterno.Cedula
                                  where padre.Cedula == estudiante.CedulaMadre
                                  select abueloPaterno).ToList();


            var abuelaPorMadre = (from madre in Contexto.Estudiantes
                                  join abuelaMaterna in Contexto.Estudiantes on madre.CedulaMadre equals abuelaMaterna.Cedula
                                  where madre.Cedula == estudiante.CedulaMadre
                                  select abuelaMaterna).ToList();

            var abuelaPorPadre = (from madre in Contexto.Estudiantes
                                  join abuelaMaterna in Contexto.Estudiantes on madre.CedulaMadre equals abuelaMaterna.Cedula
                                  where madre.Cedula == estudiante.CedulaPadre
                                  select abuelaMaterna).ToList();


            var listaDeAbuelos = abueloPorPadre.Concat(abueloPorMadre)
                            .Concat(abuelaPorMadre)
                            .Concat(abuelaPorPadre)
                            .ToList();
            return (List<Estudiante>)listaDeAbuelos.ToList();
        }

        public List<Estudiante> ObtengaLasFemeninas()
        {
            var listaDeFemeninas = from item in Contexto.Estudiantes
                                   where item.Sexo == Sexo.Femenino
                                   select item;

            List<Estudiante> estudiantes = listaDeFemeninas.ToList();


            foreach (var estudiante in estudiantes)
            {
                DateTime fechaDeNacimiento = estudiante.FechaDeNacimiento;
                int edad = DateTime.Today.Year - fechaDeNacimiento.Year;
                if (DateTime.Today < fechaDeNacimiento.AddYears(edad))
                {
                    edad--;
                }
                estudiante.Edad = edad.ToString();
            }
            return estudiantes;




        }

        public List<Estudiante> ObtengaLosMasculinos()
        {
            var listaDeMasculinos = from item in Contexto.Estudiantes
                                    where item.Sexo == Sexo.Masculino
                                    select item;

            List<Estudiante> estudiantes = listaDeMasculinos.ToList();


            foreach (var estudiante in estudiantes)
            {
                DateTime fechaDeNacimiento = estudiante.FechaDeNacimiento;
                int edad = DateTime.Today.Year - fechaDeNacimiento.Year;
                if (DateTime.Today < fechaDeNacimiento.AddYears(edad))
                {
                    edad--;
                }
                estudiante.Edad = edad.ToString();
            }
            return estudiantes;



        }

        public Estudiante ObtengaPorId(int id)
        {
            DateTime fechaDeNacimiento = DateTime.Now;
            int edad = 0;

            foreach (var estudiante in Contexto.Estudiantes)
            {
                if (estudiante.Id == id) 
                {
                    fechaDeNacimiento = estudiante.FechaDeNacimiento;
                    edad = DateTime.Today.Year - fechaDeNacimiento.Year;
                
                    if (DateTime.Today < fechaDeNacimiento.AddYears(edad))
                    {
                        edad--;
                    }
                    estudiante.Edad = edad.ToString();
                    return estudiante;
                }





            }

            

            return null;
        }
        

    }
}
