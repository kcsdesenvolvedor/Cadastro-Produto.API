using CadastroDeProdutos.API.Infra;
using CadastroDeProdutos.API.Infra.Repository;
using CadastroDeProdutos.API.Infra.Repository.Interfaces;
using CadastroDeProdutos.API.Services;
using CadastroDeProdutos.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;

namespace CadastroDeProdutos.API
{
    public class Startup
    {
        private string connection;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            InjectionRepositories(services);
            InjectionServices(services);
            connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddEntityFrameworkSqlite();
            services.AddDbContext<DataContext>();
            InjectionDb(services);
        }

        public void InjectionDb(IServiceCollection services)
        {
            services
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSQLite()
                    // Set the connection string
                    .WithGlobalConnectionString(connection)
                    // Define the assembly containing the migrations
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole());
            // Build the service provider
        }

        public void InjectionRepositories(IServiceCollection services)
        {
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }

        public void InjectionServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
