using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess.Interfaces
{
    public interface IClienteDAO
    {
        List<ClienteVO> BuscarClientes(string nome, TipoCliente tipoCliente);
        void AtualizarCliente(ClienteVO cliente);
        void RemoverCliente(int idCliente);
        void InserirCliente(ClienteVO cliente);
    }
}
