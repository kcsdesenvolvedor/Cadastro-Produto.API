using CadastroDeProdutos.API.Infra;
using CadastroDeProdutos.API.Infra.Repository;
using CadastroDeProdutos.API.Infra.Repository.Interfaces;
using CadastroDeProdutos.API.models;
using CadastroDeProdutos.API.Services;
using CadastroDeProdutos.API.Services.Interfaces;
using CadastroDeProdutos.API.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Unitario_CadProdutosTeste
{
    public class ProdutoTeste : TestWithSqlite
    {
        private IProdutoService _produtoService;

        public ProdutoTeste()
        {
            var produtoRepository = new ProdutoRepository(dataContext);
            _produtoService = new ProdutoService(produtoRepository);
            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();


        }
        [Fact(DisplayName = "Deve verificar se não salva produto com valor negativo")]
        public void DeveVerificarSeNaoSalvaProdutoComValorNegativo()
        {
            var produto = new ProdutoViewModel()
            {
                Nome = "Abacaxi",
                Estoque = 10,
                Valor = -4.50
            };

            Assert.Throws<ArgumentException>(() => _produtoService.Save(produto));
        }

    }
}
