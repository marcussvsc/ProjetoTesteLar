using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IPessoaEnderecoRepository _pessoaEnderecoRepository;
        public PessoaController(IPessoaRepository pessoaRepository, ITelefoneRepository telefoneRepository, IPessoaEnderecoRepository pessoaEnderecoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _telefoneRepository = telefoneRepository;
            _pessoaEnderecoRepository = pessoaEnderecoRepository;
        }
        [HttpGet("GetAllPessoas")]
        public ActionResult<List<Pessoa>> GetAllPessoas() 
        {            
            return Ok(_pessoaRepository.GetAllPessoas());
        }
        [HttpGet("GetPessoaById/{pessoaId}")]
        public ActionResult<PessoaDTO> GetPessoaById(int pessoaId)
        {
            PessoaDTO pessoa = _pessoaRepository.GetPessoaById(pessoaId);
            if (pessoa == null)
                return NotFound();
            return Ok(pessoa);
        }
        [HttpGet("PreencherPessoaTelefones/{pessoaId}")]
        public ActionResult<PessoaDTO> PreencherPessoaTelefones(int pessoaId)
        {
            PessoaDTO pessoa = _pessoaRepository.GetPessoaById(pessoaId);
            if (pessoa == null)
                return NotFound();
            pessoa.Telefones = _telefoneRepository.GetAllTelefonesPessoa(pessoaId);
            return Ok(pessoa);
        }
        [HttpPost("PostPessoa")]
        public ActionResult<bool> PostPessoa(Pessoa pessoa)
        {
            _pessoaRepository.PostPessoa(pessoa);
            return CreatedAtAction(nameof(GetPessoaById), new { pessoaId = pessoa.PessoaId}, pessoa);    
        }
        [HttpPost("PostPessoaEndereco/{pessoaId}/{enderecoId}")]
        public ActionResult<bool> PostPessoaEndereco(int pessoaId, int enderecoId)
        {
            _pessoaEnderecoRepository.PostPessoaEndereco(pessoaId, enderecoId);
            return true;
        }
        [HttpPut("PutPessoa/{pessoaId}")]
        public ActionResult<bool> PutPessoa(Pessoa pessoa, int pessoaId)
        {
            PessoaDTO pessoaExistente = _pessoaRepository.GetPessoaById(pessoaId);
            if (pessoaExistente == null)
                return NotFound();
            _pessoaRepository.PutPessoa(pessoa, pessoaId);
            return Ok(pessoaExistente);

        }
        [HttpDelete("DeletePessoa/{pessoaId}")]
        public ActionResult<bool> DeletePessoa(int pessoaId)
        {
            PessoaDTO pessoa = _pessoaRepository.GetPessoaById(pessoaId);
            if (pessoa == null)
                return NotFound();
            _pessoaRepository.DeletePessoa(pessoa.PessoaId);
            return NoContent();
        }
    }
}
