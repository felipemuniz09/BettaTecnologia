using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.Entities
{
    public class ClienteVO
    {
        private int id;
        
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public TipoCliente Tipo { get; set; }

        public ClienteVO(int id)
        {
            this.id = id;
        }
    }
}
