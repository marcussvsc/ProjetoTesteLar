using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.Entities;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        [HttpGet("GetAllEnderecos")]
        public ActionResult<List<Endereco>> GetAllEnderecos()
        {
            return Ok(_enderecoRepository.GetAllEnderecos());
        }
        [HttpGet("GetEnderecoById/{enderecoId}")]
        public ActionResult<Endereco> GetEnderecoById(int enderecoId)
        {
            Endereco Endereco = _enderecoRepository.GetEnderecoById(enderecoId);
            if (Endereco == null)
                return NotFound();
            return Ok(Endereco);
        }
        [HttpPost("PostEndereco")]
        public ActionResult<bool> PostEndereco(Endereco Endereco)
        {
            _enderecoRepository.PostEndereco(Endereco);
            return CreatedAtAction(nameof(GetEnderecoById), new { enderecoId = Endereco.EnderecoId }, Endereco);
        }
        [HttpPut("PutEndereco/{enderecoId}")]
        public ActionResult<bool> PutEndereco(Endereco endereco, int enderecoId)
        {
            Endereco enderecoExistente = _enderecoRepository.GetEnderecoById(enderecoId);
            if (enderecoExistente == null)
                return NotFound();
            enderecoExistente.Update(endereco.CEP, endereco.Rua, endereco.Bairro, endereco.Numero, endereco.Cidade, endereco.Estado);
            return Ok(enderecoExistente);
        }
        [HttpDelete("DeleteEndereco/{enderecoId}")]
        public ActionResult<bool> DeleteEndereco(int enderecoId)
        {
            Endereco Endereco = _enderecoRepository.GetEnderecoById(enderecoId);
            if (Endereco == null)
                return NotFound();
            _enderecoRepository.DeleteEndereco(Endereco.EnderecoId);
            return NoContent();
        }
    }
}
