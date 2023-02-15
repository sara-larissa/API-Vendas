using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dto
{
    public class ObterItemPedidoDTO
     {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ServicoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
       
        public ObterItemPedidoDTO(ItemPedido item)
        {
            Id = item.Id;
            Quantidade = item.Quantidade;
            PedidoId = item.PedidoId;
            ServicoId = item.ServicoId;
            Valor = item.Valor;
        }
    }
}