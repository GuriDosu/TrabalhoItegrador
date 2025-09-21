using Microsoft.EntityFrameworkCore;
using TrabalhoItegrador.Models;

namespace TrabalhoItegrador.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Reclamacao> Reclamacoes { get; set; }

    }
}