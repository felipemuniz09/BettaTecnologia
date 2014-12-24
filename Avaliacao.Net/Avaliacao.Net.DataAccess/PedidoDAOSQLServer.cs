using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess
{
    public class PedidoDAOSQLServer : IPedidoDAO
    {
        public List<PedidoVO> BuscarPedidos(string nomeCliente, DateTime dataPedido)
        {
            throw new NotImplementedException();
        }

        public void AtualizarPedido(PedidoVO pedido)
        {
            throw new NotImplementedException();
        }

        public void RemoverPedido(int idPedido)
        {
            throw new NotImplementedException();
        }

        public void InserirPedido(PedidoVO pedido)
        {
            throw new NotImplementedException();
        }
    }
}
