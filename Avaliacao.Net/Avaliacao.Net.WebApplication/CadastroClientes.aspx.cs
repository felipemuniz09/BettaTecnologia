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
    public partial class CadastroClientes : System.Web.UI.Page
    {
        private ClienteBLL gerenciadorClientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);
        }

        protected void Cadastrar_ServerClick(object sender, EventArgs e)
        {
            ClienteVO cliente = new ClienteVO();
            cliente.Nome = nomeTxt.Value;
            cliente.Email = emailTxt.Value;
            cliente.Telefone = telefoneTxt.Value;
            if(clientePFRadioBtn.Checked)
            {
                cliente.Tipo = TipoCliente.Fisica;
            }
            else
            {
                cliente.Tipo = TipoCliente.Juridica;
            }

            this.gerenciadorClientes.CadastrarCliente(cliente);

            nomeTxt.Value = string.Empty;
            emailTxt.Value = string.Empty;
            telefoneTxt.Value = string.Empty;

            msgConfirmacao.Attributes.Remove("style");
        }
    }
}