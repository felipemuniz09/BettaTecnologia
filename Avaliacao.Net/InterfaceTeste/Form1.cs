using Avaliacao.Net.BusinessLogic;
using Avaliacao.Net.DataAccess;
using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceTeste
{
    public partial class Form1 : Form
    {

        private ClienteBLL gerenciadorClientes;
        private PedidoBLL gerenciadorPedidos;

        public Form1()
        {
            InitializeComponent();
            IClienteDAO clienteDAO = new ClienteDAOSQLServer(ConexaoSingleton.Conexao);
            IPedidoDAO pedidoDAO = new PedidoDAOSQLServer(ConexaoSingleton.Conexao);
            this.gerenciadorClientes = new ClienteBLL(clienteDAO);
            this.gerenciadorPedidos = new PedidoBLL(pedidoDAO);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ClienteVO cliente = new ClienteVO();
            cliente.Email = "benedito@gmail.com";
            cliente.Nome = "Benedito Soares";
            cliente.Telefone = "(12) 345 678 901";
            cliente.Tipo = TipoCliente.Fisica;*/

            this.gerenciadorPedidos.BuscarPedidos(1, Convert.ToDateTime("23/12/2014"));
        }

    }
}
