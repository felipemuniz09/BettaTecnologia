using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.BusinessLogic
{
    public class ClienteBLL
    {
        private IClienteDAO clienteDAO;

        public ClienteBLL(IClienteDAO clienteDAO)
        {
            if (clienteDAO == null)
            {
                throw new ArgumentNullException("clienteDAO");
            }

            this.clienteDAO = clienteDAO;
        }

        public List<ClienteVO> BuscarClientes(string nome, TipoCliente? tipoCliente)
        {
            return this.clienteDAO.BuscarClientes(nome, tipoCliente);
        }

        public List<ClienteVO> BuscarClientes()
        {
            return this.clienteDAO.BuscarClientes(null, null);
        }

        public void EditarCliente(ClienteVO cliente)
        {
            this.clienteDAO.AtualizarCliente(cliente);
        }

        public void RemoverCliente(int idCliente)
        {
            this.clienteDAO.RemoverCliente(idCliente);
        }

        public void CadastrarCliente(ClienteVO cliente)
        {
            this.clienteDAO.InserirCliente(cliente);
        }
    }
}
