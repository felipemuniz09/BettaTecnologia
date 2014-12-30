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
        
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public int IdCliente
        {
            get
            {
                return this.cliente.Id;
            }
        }

        public string NomeCliente
        {
            get
            {
                if (this.cliente != null)
                {
                    return this.cliente.Nome;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public DateTime Data
        {
            get
            {
                return this.data;
            }
        }
    
        public PedidoVO(int id, DateTime data, ClienteVO cliente)
        {
            this.id = id;
            this.data = data;
            this.cliente = cliente;
        }

        public PedidoVO(ClienteVO cliente)
        {
            this.cliente = cliente;
        }

        public PedidoVO() { }

        public PedidoVO(int id)
        {
            this.id = id;
        }
    }
}
