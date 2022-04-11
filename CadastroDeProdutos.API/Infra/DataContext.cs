using CadastroDeProdutos.API.models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CadastroDeProdutos.API.Infra
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=cad_Produto.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Produto> Produtos { get; set; }
    }
}
