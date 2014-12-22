using Avaliacao.Net.DataAccess;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.BusinessLogic
{
    public class PedidoBLL
    {
        private PedidoDAO pedidoDAO;

        public PedidoBLL(PedidoDAO pedidoDAO) 
        {
            if (pedidoDAO == null)
            {
                throw new ArgumentNullException("pedidoDAO");
            }

            this.pedidoDAO = pedidoDAO;
        }

        public List<PedidoVO> BuscarPedidos(string nomeCliente, DateTime dataPedido)
        {
            return this.pedidoDAO.BuscarPedidos(nomeCliente, dataPedido);
        }

        public void EditarPedido(PedidoVO pedido)
        {
            this.pedidoDAO.AtualizarPedido(pedido);
        }

        public void RemoverPedido(int idPedido)
        {
            this.pedidoDAO.RemoverPedido(idPedido);
        }

        public void CadastrarPedido(PedidoVO pedido)
        {
            this.pedidoDAO.InserirPedido(pedido);
        }
    }
}
