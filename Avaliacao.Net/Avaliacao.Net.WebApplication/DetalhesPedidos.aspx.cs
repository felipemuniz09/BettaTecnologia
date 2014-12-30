using Avaliacao.Net.BusinessLogic;
using Avaliacao.Net.DataAccess;
using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avaliacao.Net.WebApplication
{
    public partial class DetalhesPedidos : System.Web.UI.Page
    {
        private PedidoBLL gerenciadorPedidos;

        protected void Page_Load(object sender, EventArgs e)
        {
            IPedidoDAO pedidoDAO = new PedidoDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorPedidos = new PedidoBLL(pedidoDAO);

            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                PedidoVO pedido = this.gerenciadorPedidos.BuscarPedido(id);

                this.clientTxt.Value = pedido.NomeCliente;
                this.dataTxt.Value = pedido.Data.ToShortDateString();
                this.valorTxt.Value = pedido.Valor.ToString();
                this.descricaoTxt.Value = pedido.Descricao;
            }
        }

        protected void Remover_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            this.gerenciadorPedidos.RemoverPedido(id);

            this.clientTxt.Value = string.Empty;
            this.dataTxt.Value = string.Empty;
            this.valorTxt.Value = string.Empty;
            this.descricaoTxt.Value = string.Empty;

            this.msgConfirmacao.Attributes.Remove("style");
        }

        protected void Salvar_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            PedidoVO pedido = this.gerenciadorPedidos.BuscarPedido(id);
            pedido.Valor = Convert.ToDecimal(this.valorTxt.Value);
            pedido.Descricao = this.descricaoTxt.Value;

            this.gerenciadorPedidos.EditarPedido(pedido);

            this.msgConfirmacaoSalvar.Attributes.Remove("style");
        }
    }
}