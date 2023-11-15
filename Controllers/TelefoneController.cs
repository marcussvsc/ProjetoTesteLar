using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public TelefoneController(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
        [HttpGet("GetAllTelefones")]
        public ActionResult<List<Telefone>> GetAllTelefones() 
        {
            return Ok(_telefoneRepository.GetAllTelefones());
        }
        [HttpGet("GetAllTelefonesPessoa/{pessoaId}")]
        public ActionResult<List<Telefone>> GetAllTelefonesPessoa(int pessoaId)
        {
            return Ok(_telefoneRepository.GetAllTelefonesPessoa(pessoaId));
        }
        [HttpGet("GetTelefoneByNumero/{numero}")]
        public ActionResult<Telefone> GetTelefoneByNumero(string numero)
        {
            Telefone telefone = _telefoneRepository.GetTelefoneByNumero(numero);
            if (telefone == null)
                return NotFound();
            return Ok(telefone);
        }
        [HttpPost("PostTelefone")]
        public ActionResult<bool> PostTelefone(Telefone telefone)
        {
            _telefoneRepository.PostTelefone(telefone);
            return CreatedAtAction(nameof(GetTelefoneByNumero), new { numero = telefone.Numero }, telefone);
        }
        [HttpPut("PutTelefone/{numero}")]
        public ActionResult<bool> PutTelefone(Telefone telefone, string numero)
        {
            Telefone telefoneExistente = _telefoneRepository.GetTelefoneByNumero(numero);
            if (telefoneExistente == null)
                return NotFound();
            telefoneExistente.Update(telefone.Numero, telefone.Tipo);
            return Ok(telefoneExistente);
        }
        [HttpDelete("DeleteTelefone/{telefone}")]
        public ActionResult<bool> DeleteTelefone(string numero)
        {
            Telefone telefone = _telefoneRepository.GetTelefoneByNumero(numero);
            if (telefone == null)
                return NotFound();
            _telefoneRepository.DeleteTelefone(telefone.Numero);
            return NoContent();
        }
    }
}
