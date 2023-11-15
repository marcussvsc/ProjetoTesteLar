﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteLar.DTOs;

namespace ProjetoTesteLar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pessoa>> GetAllPessoas() 
        {
            return Ok();
        }
        [HttpGet("{cpf}")]
        public ActionResult<Pessoa> GetPessoaByCpf(string cpf)
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult<bool> PostPessoa(Pessoa pessoa)
        {
            return Ok();    
        }
        [HttpPut]
        public ActionResult<bool> PostPessoa(Pessoa pessoa, string cpf)
        {
            return Ok();
        }
        [HttpDelete("{cpf}")]
        public ActionResult<bool> DeletePessoa(string cpf)
        {
            return Ok();
        }
    }
}
