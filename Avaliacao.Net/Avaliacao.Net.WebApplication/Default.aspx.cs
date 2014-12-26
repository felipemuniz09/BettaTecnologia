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
    public partial class _Default : Page
    {
        private ClienteBLL gerenciadorClientes;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);
        }

        protected void selecionarClientesBtn_Click(object sender, EventArgs e)
        {
            this.gerenciadorClientes.BuscarClientes(string.Empty, null);
        }
    }
}