using CadastroDeProdutos.API.Infra.Repository.Interfaces;
using CadastroDeProdutos.API.models;
using CadastroDeProdutos.API.Services.Interfaces;
using CadastroDeProdutos.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeProdutos.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void Delete(int id)
        {
            _produtoRepository.Delete(id);
        }

        public Produto GetById(int id)
        {
            return _produtoRepository.GetById(id);
        }

        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }

        public void Save(ProdutoViewModel model)
        {
            
            var produto = ProdutoViewModel.CreateProduto(model);

            if(VerificaValor(produto.Valor))
                _produtoRepository.Save(produto);
        }

        public void Update(int id, ProdutoViewModel model)
        {
            var produto = ProdutoViewModel.UpdateProduto(id, model);

            if (VerificaValor(produto.Valor))
                _produtoRepository.Update(produto);
        }

        public bool VerificaValor(double valor)
        {
            if(valor > 0)
                return true;

            throw new System.ArgumentException("O valor deve ser maior que zero!");
        }
    }
}
