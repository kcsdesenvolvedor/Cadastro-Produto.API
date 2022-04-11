using CadastroDeProdutos.API.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeProdutos.API.Infra.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> GetProdutos();
        Produto GetById(int id);
        void Save(Produto produto);
        void Delete(int id);
        void Update(Produto produto);
    }
}
