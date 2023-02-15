using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Dto;

namespace API.Repository
{
    public class VendedorRepository
    {
        private readonly VendasContext _context;

        public VendedorRepository(VendasContext context) 
        {
            _context = context; 
        }

        public void Cadastrar(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges(); //comando que salva no Banco de Dados;
        }

        public Vendedor ObterPorId(int id)
        {
            var vendedor = _context.Vendedores.Find(id); //OBTENDO POR ID
            return vendedor;
        }

        public List<ObterVendedorDTO> ObterPorNome(string nome)
        {
            var vendedores = _context.Vendedores.Where(x => x.Nome.Contains(nome)) //para cada vendedor tenho que conter um nome - Pesquisando os nomes
                                                .Select(x => new ObterVendedorDTO(x)) // select: transformação de dados, estou pegando uma classe chamada VENDEDOR, selecionando o new ObterVendedorDto(criando uma classe) -  Transformando em DTO;
                                                .ToList(); //E fazendo um ToList;

            return vendedores;                                    
        }
        public Vendedor AtualizarVendedor( Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();

            return vendedor;
        }

        public void DeletarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
        }

        public void AtualizarSenha (Vendedor vendedor, AtualizarSenhaVendedorDTO dto)
        {
            vendedor.Senha = dto.Senha;
            AtualizarVendedor(vendedor);
        }

        public List<Vendedor> Listar()
        {
            return _context.Vendedores.ToList();
        }
    }
}