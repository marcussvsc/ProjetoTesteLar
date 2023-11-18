using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.DTOs.TelefoneDTos;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IPessoaRepository _pessoaRepository;
        public TelefoneController(ITelefoneRepository telefoneRepository, IPessoaRepository pessoaRepository)
        {
            _telefoneRepository = telefoneRepository;
            _pessoaRepository = pessoaRepository;
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
        public async Task<ActionResult<bool>> PostTelefone(CreateTelefoneDTO createTelefoneDTO)
        {
            PessoaDTO pessoa = await _pessoaRepository.GetPessoaById(createTelefoneDTO.PessoaId);
            if(pessoa == null)
                return NotFound();
            Telefone telefone  = new Telefone() 
            {
                PessoaId = createTelefoneDTO.PessoaId,
                Numero = createTelefoneDTO.Numero,
                Tipo = createTelefoneDTO.Tipo
            };
            telefone.Pessoa = pessoa;
            await _telefoneRepository.PostTelefone(telefone);
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
            _telefoneRepository.DeleteTelefone(telefone.TelefoneId);
            return NoContent();
        }
    }
}
