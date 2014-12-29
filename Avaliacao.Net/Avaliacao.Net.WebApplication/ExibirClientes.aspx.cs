using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Avaliacao.Net.WebApplication
{
    public partial class ExibirClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ClienteVO> clientes = PreviousPage.Clientes;

            foreach(ClienteVO cliente in clientes)
            {
                HtmlTableRow tbRow = new HtmlTableRow();

                //ID, Nome, Email, Telefone, Tipo de Cliente

                HtmlTableCell tbCell = new HtmlTableCell();
                tbCell.InnerText = cliente.Id.ToString();
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = cliente.Nome;
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = cliente.Email;
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = cliente.Telefone;
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                if(cliente.Tipo.Equals(TipoCliente.Fisica))
                {
                    tbCell.InnerText = "Pessoa Física";
                }
                else
                {
                    tbCell.InnerText = "Pessoa Jurídica";
                }
                tbRow.Controls.Add(tbCell);

                this.clientesTb.Rows.Add(tbRow);
            }
        }
    }
}