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
    public partial class CadastrarPedidos : System.Web.UI.Page
    {
        private ClienteBLL gerenciadorClientes;
        private PedidoBLL gerenciadorPedidos;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);

            IPedidoDAO pedidoDAO = new PedidoDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorPedidos = new PedidoBLL(pedidoDAO);
            
            if (!Page.IsPostBack)
            {
                this.clienteSel.DataSource = this.gerenciadorClientes.BuscarClientes();
                this.clienteSel.DataTextField = "Nome";
                this.clienteSel.DataValueField = "Id";
                this.clienteSel.DataBind();
            }
        }

        protected void Cadastrar_ServerClick(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(this.clienteSel.Value);

            PedidoVO pedido = new PedidoVO(new ClienteVO(clienteId));
            pedido.Descricao = this.descricaoTxt.Value;
            pedido.Valor = Convert.ToDecimal(this.valorTxt.Value);

            this.gerenciadorPedidos.CadastrarPedido(pedido);

            this.descricaoTxt.Value = string.Empty;
            this.valorTxt.Value = string.Empty;

            this.msgConfirmacao.Attributes.Remove("style");
        }

        protected void clienteSel_ServerChange(object sender, EventArgs e)
        {

        }
    }
}