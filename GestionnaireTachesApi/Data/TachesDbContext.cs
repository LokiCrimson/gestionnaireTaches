using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Models;

namespace GestionnaireTachesApi.Data
{
    public class TachesDbContext : DbContext
    {
        public TachesDbContext(DbContextOptions<TachesDbContext> options)
            : base(options) { }

        public DbSet<Projet> Projets { get; set; }
        public DbSet<Tache> Taches { get; set; }
    }
}
