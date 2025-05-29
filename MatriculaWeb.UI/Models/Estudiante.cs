using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MatriculaWeb.UI.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cedula es requerido")]
        public String Cedula { get; set; }
        [Required(ErrorMessage = "El campo del Nombre es requerido")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El campo del Primer Apellido es requerido")]
        public String PrimerApellido { get; set; }

        [Required(ErrorMessage = "El campo del Segundo Apellido es requerido")]
        public String SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo del Sexo es requerido")]
        public Sexo Sexo { get; set; }


        [Required(ErrorMessage = "El campo de la Fecha es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [NotMapped]
        public String Edad { get; set; }

        [Required(ErrorMessage = "El campo Cedula de la madre es requerido")]
        public String CedulaMadre { get; set; }

        [Required(ErrorMessage = "El campo Cedula del padre es requerido")]
        public String CedulaPadre { get; set; }

        public HistorialFamiliar historialFamiliar;

        public Estudiante()
        {
            historialFamiliar = new HistorialFamiliar();

        }
    }
}
