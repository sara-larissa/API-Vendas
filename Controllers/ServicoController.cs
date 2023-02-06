using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {
       private readonly ServicoRepository _repository;

        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarServicoDTO dto)
        {
            var Servico = new Servico(dto);
            _repository.Cadastrar(Servico);
            return Ok(Servico);
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var servico = _repository.Listar();

            if(servico is not null)
            {
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Não há servicos"});
            }
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                servico.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servico);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Servico não encontrado ou não existente"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);


            if(servico is not null)
            {
                _repository.DeletarServico(servico);
                return NoContent();

            }
             else
            {
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        
        }
    }
}