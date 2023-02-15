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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository  repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);

            if (cliente is not null) //FUNÇÃO PARA NÃO MOSTRAR A SENHA NA PESQUISA;
            {   
                var clienteDTO = new ObterClienteDTO(cliente);
                return Ok(clienteDTO);
            }
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado"}) ;    
            }   

        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var clientes = _repository.ObterPorNome(nome);
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);

            if(cliente is not null)
            {
                cliente.MapearAtualizarCliente(dto);
                _repository.AtualizarCliente(cliente);
                return Ok(cliente);
            } 
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _repository.ObterPorId(id);

            if(cliente is not null)
            {
                _repository.DeletarCliente(cliente);
                return NoContent(); //NoContent resposta vazia para a API;
            }
            else
            {
                 return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarSenha(int id, AtualizarSenhaClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);

            if (cliente is not null)
            {
                _repository.AtualizarSenha(cliente, dto);
                return Ok(cliente);

            } else {
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

    [HttpGet("Listar")]
     public IActionResult Listar()
        {
            var cliente = _repository.Listar();
            return Ok(cliente);
        }
    }
}