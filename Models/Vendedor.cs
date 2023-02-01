using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;

namespace API
{
    public class Vendedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public Vendedor()
        {
            
        }

        public Vendedor(CadastrarVendedorDTO dto)
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }

        public void MapearAtualizarVendedorDTO(AtualizarVendedorDTO dto) //dto uma classe para transferir objetos para outro objeto;
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }

    }
}