using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;

namespace API.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int VendedorId { get; set; } //(Quando tenho uma classe estrangeira(vendedorId), preciso de uma Model(classe) abaixo)

        public Vendedor Vendedor { get; set; } //(CLASSE CHAMADA VENDEDOR, PARA PODERMOS NAGEVAR E FAZER A PASSAGEM DOS DADOS, SE EU QUISER VER O NOME DO VENDEDOR EU ACESSO PEDIDO E ACESSOR A MINHA PROPRIEDADE VENDEDOR);

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } //(CLASSE CHAMADA CLIENTES, PARA PODERMOS NAGEVAR E FAZER A PASSAGEM DOS DADOS, SE EU QUISER VER O NOME DO CLIENTES EU ACESSO PEDIDO E ACESSOR A MINHA PROPRIEDADE VENDEDOR);


        public Pedido()
        {

        }

        public Pedido(CadastrarPedidoDTO dto)
        {
            Data = dto.Data;
            VendedorId = dto.VendedorId;
            ClienteId = dto.ClienteId;
        }

        public void MapearAtualizarPedidoDTO(AtualizarPedidoDTO dto)
        {
            Data = dto.Data;
            VendedorId = dto.VendedorId;
            ClienteId = dto.ClienteId;
        }
    }

}