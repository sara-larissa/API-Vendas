using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ObterVendedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public ObterVendedorDTO(Vendedor vendedor)
        {
            Id = vendedor.Id;
            Nome = vendedor.Nome;
            Login = vendedor.Login;
            Senha = vendedor.Senha;
        }
        
    }
}