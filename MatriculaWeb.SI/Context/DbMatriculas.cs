using MatriculaWeb.SI.Model;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWeb.SI.Context
{
    public class DbMatriculas : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbMatriculas(DbContextOptions<DbMatriculas> opciones) : base(opciones)
        {

        }
    }
}
