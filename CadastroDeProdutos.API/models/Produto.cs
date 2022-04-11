using System;

namespace CadastroDeProdutos.API.models
{
    public class Produto
    {
        public Produto()
        {
            DataInclusaoProduto = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double Valor { get; set; }
        public DateTime DataInclusaoProduto { get; set; }
    }
}
