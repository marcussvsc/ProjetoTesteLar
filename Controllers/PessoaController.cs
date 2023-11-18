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
        private readonly IEnderecoRepository _enderecoRepository;
        public PessoaController(IPessoaRepository pessoaRepository, ITelefoneRepository telefoneRepository, IPessoaEnderecoRepository pessoaEnderecoRepository, IEnderecoRepository enderecoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _telefoneRepository = telefoneRepository;
            _pessoaEnderecoRepository = pessoaEnderecoRepository;
            _enderecoRepository = enderecoRepository;
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
        public ActionResult<bool> PostPessoa(PessoaDTO pessoa)
        {
            _pessoaRepository.PostPessoa(pessoa);
            return CreatedAtAction(nameof(GetPessoaById), new { pessoaId = pessoa.PessoaId}, pessoa);    
        }
        [HttpPost("PostPessoaEndereco/{pessoaId}/{enderecoId}")]
        public ActionResult<bool> PostPessoaEndereco(int pessoaId, int enderecoId)
        {
            _pessoaEnderecoRepository.PostPessoaEndereco(pessoaId, enderecoId);
            return NoContent();
        }
        [HttpPost("PreencherPessoaEnderecos/{pessoaId}")]
        public ActionResult<Pessoa> PreencherPessoaEnderecos(int pessoaId)
        {
            PessoaDTO pessoa = _pessoaRepository.GetPessoaById(pessoaId);
            if(pessoa == null)
                return NotFound();
            _pessoaEnderecoRepository.GetPessoaEnderecosByPessoaId(pessoaId).ForEach(p => 
            {
                if (pessoa.Enderecos == null)
                    pessoa.Enderecos = new List<Entities.Endereco>();
                pessoa.Enderecos.Add(_enderecoRepository.GetEnderecoById(p.EnderecoId));
            });
            return Ok(pessoa);
        }
        [HttpPut("PutPessoa/{pessoaId}")]
        public ActionResult<bool> PutPessoa(PessoaDTO pessoa, int pessoaId)
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
