using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto // Objeto para transferencia de dados ( data transfer object)
{
    public class CadastrarVendedorDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        
    }
}