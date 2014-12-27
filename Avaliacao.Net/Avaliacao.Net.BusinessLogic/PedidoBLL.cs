﻿using Avaliacao.Net.DataAccess.Interfaces;
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
        private IPedidoDAO pedidoDAO;

        public PedidoBLL(IPedidoDAO pedidoDAO) 
        {
            if (pedidoDAO == null)
            {
                throw new ArgumentNullException("pedidoDAO");
            }

            this.pedidoDAO = pedidoDAO;
        }

        public List<PedidoVO> BuscarPedidos(int? idCliente, DateTime? dataPedido)
        {
            return this.pedidoDAO.BuscarPedidos(idCliente, dataPedido);
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
