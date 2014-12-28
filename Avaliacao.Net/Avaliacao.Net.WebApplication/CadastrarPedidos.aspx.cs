using Avaliacao.Net.BusinessLogic;
using Avaliacao.Net.DataAccess;
using Avaliacao.Net.DataAccess.Interfaces;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);

            this.clienteSel.DataSource = this.gerenciadorClientes.BuscarClientes();
            this.clienteSel.DataTextField = "Nome";
            this.clienteSel.Value = "Id";
            this.clienteSel.DataBind();
        }
    }
}