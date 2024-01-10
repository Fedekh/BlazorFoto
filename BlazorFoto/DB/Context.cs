
using BlazorFoto.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorFoto.Components.DB
{
    public class Context : DbContext
    {
        public DbSet<Foto> Foto { get; set; }
        public DbSet<Category> Category { get; set; }

        private readonly IConfiguration _configuration;

        public Context(DbContextOptions<Context> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("OfficeConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }

            //if (!optionsBuilder.IsConfigured)
            //{
            //    string connectionString = _configuration.GetConnectionString("DefaultConnection");
            //    optionsBuilder.UseSqlServer(connectionString);
            //}
        }
    }
}
