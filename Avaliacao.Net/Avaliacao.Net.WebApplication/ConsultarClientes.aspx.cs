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
    public partial class ConsultarClientes : System.Web.UI.Page
    {
        private ClienteBLL gerenciadorClientes;
        private List<ClienteVO> clientes;

        public List<ClienteVO> Clientes
        {
            get
            {
                return this.clientes;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);
        }

        protected void Consultar_ServerClick(object sender, EventArgs e)
        {
            int tpSelecionado = Convert.ToInt32(this.tpClienteSel.Value);

            TipoCliente? tipoCliente;

            if(tpSelecionado == 0)
            {
                tipoCliente = TipoCliente.Fisica;
            }
            else if(tpSelecionado == 1)
            {
                tipoCliente = TipoCliente.Juridica;
            }
            else
            {
                tipoCliente = null;
            }

            this.clientes = this.gerenciadorClientes.BuscarClientes(this.nomeCliente.Value, tipoCliente);

            // Redireciona para a página ExibirClientes.aspx
            this.Server.Transfer("ExibirClientes.aspx");
        }
    }
}