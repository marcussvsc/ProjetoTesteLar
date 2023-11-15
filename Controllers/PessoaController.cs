using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        [HttpGet("GetAllPessoas")]
        public ActionResult<List<Pessoa>> GetAllPessoas() 
        {            
            return Ok(_pessoaRepository.GetAllPessoas());
        }
        [HttpGet("GetPessoaByCpf/{cpf}")]
        public ActionResult<Pessoa> GetPessoaByCpf(string cpf)
        {
            Pessoa pessoa = _pessoaRepository.GetPessoaByCpf(cpf);
            if (pessoa == null)
                return NotFound();
            return Ok(pessoa);
        }
        [HttpPost("PostPessoa")]
        public ActionResult<bool> PostPessoa(Pessoa pessoa)
        {
            _pessoaRepository.PostPessoa(pessoa);
            return CreatedAtAction(nameof(GetPessoaByCpf), new { cpf = pessoa.CPF}, pessoa);    
        }
        [HttpPut("PutPessoa/{cpf}")]
        public ActionResult<bool> PutPessoa(Pessoa pessoa, string cpf)
        {
            Pessoa pessoaExistente = _pessoaRepository.GetPessoaByCpf(cpf);
            if (pessoa == null)
                return NotFound();
            pessoaExistente.Update(pessoa.Nome, pessoa.CPF, pessoa.DtNascimento, pessoa.Ativo);
            return Ok(pessoa);

        }
        [HttpDelete("DeletePessoa/{cpf}")]
        public ActionResult<bool> DeletePessoa(string cpf)
        {
            Pessoa pessoa = _pessoaRepository.GetPessoaByCpf(cpf);
            if (pessoa == null)
                return NotFound();
            _pessoaRepository.DeletePessoa(pessoa.CPF);
            return NoContent();
        }
    }
}
