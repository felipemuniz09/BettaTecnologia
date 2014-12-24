using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess
{
    public class ClienteDAOSQLServer : IClienteDAO
    {
        public List<ClienteVO> BuscarClientes(string nome, TipoCliente tipoCliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarCliente(ClienteVO cliente)
        {
            throw new NotImplementedException();
        }

        public void RemoverCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void InserirCliente(ClienteVO cliente)
        {
            throw new NotImplementedException();
        }
    }
}
