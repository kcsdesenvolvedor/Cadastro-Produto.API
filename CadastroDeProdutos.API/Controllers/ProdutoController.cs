using CadastroDeProdutos.API.Services.Interfaces;
using CadastroDeProdutos.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CadastroDeProdutos.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoService.GetProdutos());
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByIdA([FromRoute] int id)
        {
            try
            {
                var produto = _produtoService.GetById(id);
                if (produto != null)
                {
                    return Ok(produto);
                }
                else
                {
                    return NotFound(new { message = "Produto não encontrado!" });
                }
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoViewModel produto)
        {
            try
            {
                _produtoService.Save(produto);
                return Ok(new { message = "Produto adicionado com sucesso!" });
            }
            catch (System.ArgumentException error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoViewModel model)
        {
            try
            {
                _produtoService.Update(id, model);
                return Ok(new { message = "Produto alterado com sucesso!" });
            }
            catch (System.ArgumentException error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var produto = _produtoService.GetById(id);
                if (produto != null)
                {
                    _produtoService.Delete(id);
                    return Ok(new { message = "Produto deletado com sucesso!"});
                }
                else
                {
                    return NotFound(new { message = "Produto não encontrado!" });
                }
            }
            catch (System.Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
