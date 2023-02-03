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
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarPedidoDTO dto)
        {
            var pedido = new Pedido(dto);
            _repository.Cadastrar(pedido);

            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _repository.ObterPorId(id);

            if(pedido is not null)
            {
                var pedidoDTO = new ObterPedidoDTO(pedido);
                return Ok(pedido);
            } 
            else 
            {
                return NotFound(new { Mensagem = "Pedido não encontrado" });
            }
        }

         [HttpGet("ConsultarPorVendedor/{id}")]
        public IActionResult ConsultarPorVendedor(int id)
        {
            var vendedor = _repository.ObterVendedorPedido(id);

            if(vendedor is not null)
            {
                return Ok(vendedor);
            }
            else
            {
                return NotFound(new { Mensagem = "Este vendedor não possui nenhum pedido"});
            }
        }
        [HttpGet("ConsultarPorCliente/{id}")]
        public IActionResult ConsultarPorCliente(int id)
        {
            var cliente = _repository.ObterClientePedido(id);

            if(cliente is not null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound(new { Mensagem = "Este cliente não possui nenhum pedido"});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);
            
            if(pedido is not null)
            {
                pedido.MapearAtualizarPedidoDTO(dto);
                _repository.AtualizarPedido(pedido);
                return Ok(pedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Pedido não encontrado!"});
            }
        
        }


    }
}