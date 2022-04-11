using CadastroDeProdutos.API.models;
using CadastroDeProdutos.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeProdutos.API.Services.Interfaces
{
    public interface IProdutoService
    {
        public List<Produto> GetProdutos();
        public Produto GetById(int id);
        public void Save(ProdutoViewModel model);
        public void Delete(int id);
        public void Update(int id, ProdutoViewModel model);
    }
}
