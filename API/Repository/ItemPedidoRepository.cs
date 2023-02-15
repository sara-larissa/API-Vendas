using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dto;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;

        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItensPedido.Add(itemPedido);
            _context.SaveChanges();
        }

        // public List<ItemPedido> Listar()
        // {
        //     var item = _context.ItensPedido.ToList();
        //     return item;
        // }

        public ItemPedido ObterPorId(int id)
        {
            var item = _context.ItensPedido.Include(x => x.ServicoId)
                                           .Include(x => x.Pedido)
                                           .FirstOrDefault(x => x.Id == id);
            return item; 
        }

        public ItemPedido AtualizarItemPedido(ItemPedido item)
        {
            _context.ItensPedido.Update(item);
            _context.SaveChanges();

            return item;
        }
        
        public void DeletarItemPedido(ItemPedido item)
        {
            _context.ItensPedido.Remove(item);
            _context.SaveChanges();
        }
          public List<ItemPedido> Listar()
        {
            return _context.ItensPedido.ToList();
        }
    }
}