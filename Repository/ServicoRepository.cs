using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dto;
using API.Models;

namespace API.Repository
{


    public class ServicoRepository
    {
         private readonly VendasContext _context;

        public ServicoRepository(VendasContext context)
        {
            _context = context;
        }
        
        public void Cadastrar(Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
        }
          public List<Servico> Listar()
        {
            var servico = _context.Servicos.ToList();
            return servico;
        }

        public Servico ObterPorId(int id)
        {
            var servico = _context.Servicos.Find(id);

            return servico;
        }

        public Servico AtualizarServico(Servico servico)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return servico;
        }

        public void DeletarServico(Servico servico)
        {
            _context.Servicos.Remove(servico);
            _context.SaveChanges();
        }
    }
}

