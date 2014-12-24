using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess.Interfaces
{
    public interface IPedidoDAO
    {
        List<PedidoVO> BuscarPedidos(string nomeCliente, DateTime dataPedido);
        void AtualizarPedido(PedidoVO pedido);
        void RemoverPedido(int idPedido);
        void InserirPedido(PedidoVO pedido);
    }
}
