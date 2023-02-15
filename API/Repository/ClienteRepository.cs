using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dto;
using API.Models;

namespace API.Repository
{
    public class ClienteRepository
    {
        private readonly VendasContext _context;

        public ClienteRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public List<ObterClienteDTO> ObterPorNome(string nome)
        {
            var clientes = _context.Clientes.Where(x => x.Nome.Contains(nome))
                                            .Select(x => new ObterClienteDTO(x))
                                            .ToList();
            return clientes;                                
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges(); //SaveChanges tem que ser ultilizado sempre que que for feita alguma mudança no banco de dados;
            return cliente;
        }

        public void DeletarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void AtualizarSenha(Cliente cliente, AtualizarSenhaClienteDTO dto)
        {
            cliente.Senha = dto.Senha;
            AtualizarCliente(cliente);

 
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }
    }
}