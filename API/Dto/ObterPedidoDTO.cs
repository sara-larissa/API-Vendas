using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dto
{
    public class ObterPedidoDTO
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int VendedorId { get; set; } 

        public int ClienteId { get; set; }

        public ObterPedidoDTO(Pedido pedido)
        {
            Id = pedido.Id;
            Data = pedido.Data;
            VendedorId = pedido.VendedorId;
            ClienteId = pedido.ClienteId;
        }
    }
}