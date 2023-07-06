using Gestionador.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestionador.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Equipos>Equipos { get; set; }  
        public DbSet<Jugadores> Jugadores { get; set;}
        public DbSet<Partidos> Partidos { get; set; }
        public DbSet<Estadisticas> Estadisticas { get; set; }
    }
}