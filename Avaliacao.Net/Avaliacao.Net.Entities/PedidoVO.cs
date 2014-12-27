using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.Entities
{
    public class PedidoVO
    {
        private int id;
        private ClienteVO cliente;
        private DateTime data;

        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public PedidoVO(int id, DateTime data, ClienteVO cliente)
        {
            this.id = id;
            this.data = data;
            this.cliente = cliente;
        }
    }
}
