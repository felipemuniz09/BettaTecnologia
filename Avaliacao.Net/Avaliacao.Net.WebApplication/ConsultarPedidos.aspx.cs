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
    public partial class ConsultarPedidos : System.Web.UI.Page
    {
        private PedidoBLL gerenciadorPedidos;
        private List<PedidoVO> pedidos;

        public List<PedidoVO> Pedidos
        {
            get
            {
                return this.pedidos;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IPedidoDAO pedidoDAO = new PedidoDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorPedidos = new PedidoBLL(pedidoDAO);
        }

        protected void Consultar_ServerClick(object sender, EventArgs e)
        {
            DateTime? dtInicial = null, dtFinal = null;

            if(!string.IsNullOrEmpty(this.dtInicialPedidoTxt.Value))
            {
                dtInicial = Convert.ToDateTime(this.dtInicialPedidoTxt.Value);
            }
       
            if(!string.IsNullOrEmpty(this.dtFinalPedidoTxt.Value))
            {
                dtFinal = Convert.ToDateTime(this.dtFinalPedidoTxt.Value);
            }

            this.pedidos = this.gerenciadorPedidos.BuscarPedidos(this.nomeClienteTxt.Value, dtInicial, dtFinal);

            this.Server.Transfer("ExibirPedidos.aspx");
        }
    }
}