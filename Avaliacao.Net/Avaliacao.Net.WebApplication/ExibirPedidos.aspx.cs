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
    public partial class ExibirPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PreviousPage é diferente de nulo apenas na primeira vez que a página é carregada, 
            // por isso a lista de pedidos fica armazenada na Session
            if(PreviousPage != null)
            {
                this.Session["pedidos"] = PreviousPage.Pedidos;
            }

            List<PedidoVO> pedidos = ((IList<PedidoVO>)this.Session["pedidos"]).ToList();

            foreach(PedidoVO pedido in pedidos)
            {
                HtmlTableRow tbRow = new HtmlTableRow();
                HtmlTableCell tbCell;

                // ID, Cliente, Data, Descrição, Valor

                tbCell = new HtmlTableCell();
                tbCell.InnerText = pedido.Id.ToString();
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = pedido.NomeCliente;
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = pedido.Data.ToShortDateString();
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = pedido.Descricao;
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                tbCell.InnerText = pedido.Valor.ToString();
                tbRow.Controls.Add(tbCell);

                tbCell = new HtmlTableCell();
                HtmlAnchor link = new HtmlAnchor();
                link.Attributes.Add("href", "DetalhesPedidos.aspx?id=" + pedido.Id);
                link.InnerText = "detalhes";
                tbCell.Controls.Add(link);
                tbRow.Controls.Add(tbCell);

                this.pedidosTb.Rows.Add(tbRow);
            }
        }
    }
}