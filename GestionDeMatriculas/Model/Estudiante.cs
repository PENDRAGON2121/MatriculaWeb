using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMatriculas.Model
{
    public class Estudiante
    {
        public int Id { get; set; }

        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }

        public Sexo Sexo { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        public String Edad { get; set; }

        public String CedulaMadre { get; set; }

        public String CedulaPadre { get; set; }

        public HistorialFamiliar historialFamiliar;

        public Estudiante()
        {
            historialFamiliar = new HistorialFamiliar();

        }
    }
}
