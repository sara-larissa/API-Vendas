using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context  //o que é um Conntext? Uma classe que acessa o banco de dados;, ela precisa herdar de DBcontext; Que vem do EntityFramework core
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options) :base(options)
        {

        }

              //Tudo que for tabela colocar como DbSet

        public DbSet<Cliente> Clientes {get; set; }
        public DbSet<ItemPedidos> ItensPedido {get; set; }
        public DbSet<Pedido> Pedidos {get; set; }
        public DbSet<Servico> Serviços {get; set; }
        public DbSet<Vendedor> Vendedores {get; set; }

    }
}