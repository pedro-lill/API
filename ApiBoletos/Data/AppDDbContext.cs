using Microsoft.EntityFrameworkCore;
using BoletoAPI.Models;

namespace BoletoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
    }
}