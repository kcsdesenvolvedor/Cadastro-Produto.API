using CadastroDeProdutos.API.models;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeProdutos.API.ViewModels
{
    public class ProdutoViewModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo estoque é obrigatório")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public double Valor { get; set; }

        public static Produto CreateProduto(ProdutoViewModel model)
        {
            return new Produto() 
            {
                Nome = model.Nome,
                Estoque = model.Estoque,
                Valor = model.Valor
            };
        } 

        public static Produto UpdateProduto(int id, ProdutoViewModel model)
        {
            return new Produto()
            {
                Id = id,
                Nome = model.Nome,
                Estoque = model.Estoque,
                Valor = model.Valor
            };
        }
    }
}
