
using CadastroDeProdutos.API.Infra;
using CadastroDeProdutos.API.models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitario_CadProdutosTeste
{
   public class TestWithSqlite
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly DataContext dataContext;

        protected TestWithSqlite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(_connection)
                    .Options;
            dataContext = new DataContext();
            

        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
