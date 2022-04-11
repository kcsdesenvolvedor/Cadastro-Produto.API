using CadastroDeProdutos.API.Infra.Repository.Interfaces;
using CadastroDeProdutos.API.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeProdutos.API.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Delete(int id)
        {
            var produto = GetById(id);
            _dataContext.Produtos.Remove(produto);
            _dataContext.SaveChanges();
        }

        public Produto GetById(int id)
        {
            return _dataContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<Produto> GetProdutos()
        {
            return _dataContext.Produtos.ToList();
        }

        public void Save(Produto produto)
        {
            _dataContext.Produtos.Add(produto);
            _dataContext.SaveChanges();
        }

        public void Update(Produto produto)
        {
            //_dataContext.Entry<Produto>(produto).State = EntityState.Modified;
            _dataContext.Produtos.Update(produto);
            _dataContext.SaveChanges();
        }
    }
}
