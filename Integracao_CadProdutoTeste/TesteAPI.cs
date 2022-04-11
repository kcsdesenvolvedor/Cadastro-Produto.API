using CadastroDeProdutos.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Integracao_CadProdutoTeste
{
    public class TesteAPI : IClassFixture<CustomerTeste<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomerTeste<Startup> _factory;

        public TesteAPI(CustomerTeste<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("https://localhost:5001/v1/"),
                HandleCookies = true,
                MaxAutomaticRedirections = 10
            });
        }


        [Theory]
        [InlineData("produto")]
        public async Task DeveVerificarSeApiEstaRespondendoComSucesso(string url)
        {
            // Arrange
            var request = await _client.GetAsync(url);

            // Act
            var response = request.StatusCode;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response);
        }
    }
}
