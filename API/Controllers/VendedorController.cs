using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers // ponto de entrada da API, a API faz uma exposição de métodos e ela faz essa exposição através da controller;

{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorRepository _repository;

        public VendedorController(VendedorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarVendedorDTO dto)
        {
            var Vendedor = new Vendedor(dto);
            _repository.Cadastrar(Vendedor);
            return Ok(Vendedor);
        }

        [HttpGet("{id}")]
        public IActionResult ObterporId(int id)
        {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                var vendedorDTO = new ObterVendedorDTO(vendedor);
                return Ok(vendedorDTO);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome (string nome)
        {
            var vendedores = _repository.ObterPorNome(nome);

            return Ok(vendedores);
        }
       
       [HttpPut("{id}")]
       public IActionResult Atualizar(int id, AtualizarVendedorDTO dto)
       {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                vendedor.MapearAtualizarVendedorDTO(dto);
                _repository.AtualizarVendedor(vendedor);
                return Ok(vendedor);
            } 
            else 
            {
                return NotFound(new { Mensagem = "Vendedor não encontrado"});
            }
       }
       [HttpDeleteAttribute("{id}")]
       public IActionResult Deletar(int id)
       {
            var vendedor = _repository.ObterPorId(id);

            if(vendedor is not null)
            {
                _repository.DeletarVendedor(vendedor);
                return NoContent();
            } 
            else 
            {
                return NotFound(new {Mensagem = "Vendedor não encontrado"});
            }
       }

        [HttpPatch("{id}")]
       public IActionResult AtualizarSenha(int id, AtualizarSenhaVendedorDTO dto)
       {
            var vendedor = _repository.ObterPorId(id);
            
            if (vendedor is not null)
            {
                _repository.AtualizarSenha(vendedor, dto);
                return Ok (vendedor);
            }
            else 
            {
                return NotFound(new {Mensagem = "Vendedor não encontrado"});
            }
       }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var vendedores = _repository.Listar();
            return Ok(vendedores);
        }

    }
    
}