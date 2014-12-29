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
    public partial class Detalhes : System.Web.UI.Page
    {
        private ClienteBLL gerenciadorClientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);

            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                ClienteVO cliente = this.gerenciadorClientes.BuscarCliente(id);

                this.nomeTxt.Value = cliente.Nome;
                this.emailTxt.Value = cliente.Email;
                this.telefoneTxt.Value = cliente.Telefone;

                if (cliente.Tipo.Equals(TipoCliente.Fisica))
                {
                    this.clientePFRadioBtn.Checked = true;
                    this.clientePJRadioBtn.Checked = false;
                }
                else
                {
                    this.clientePJRadioBtn.Checked = true;
                    this.clientePFRadioBtn.Checked = false;
                }
            }
        }

        protected void Remover_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            this.gerenciadorClientes.RemoverCliente(id);

            this.nomeTxt.Value = string.Empty;
            this.emailTxt.Value = string.Empty;
            this.telefoneTxt.Value = string.Empty;

            this.msgConfirmacao.Attributes.Remove("style");
        }

        protected void Salvar_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            ClienteVO cliente = new ClienteVO(id);
            cliente.Nome = nomeTxt.Value;
            cliente.Email = emailTxt.Value;
            cliente.Telefone = telefoneTxt.Value;
            if (clientePFRadioBtn.Checked)
            {
                cliente.Tipo = TipoCliente.Fisica;
            }
            else
            {
                cliente.Tipo = TipoCliente.Juridica;
            }

            this.gerenciadorClientes.EditarCliente(cliente);

            this.msgConfirmacaoSalvar.Attributes.Remove("style");
        }
    }
}