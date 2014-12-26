using Avaliacao.Net.DataAccess.Interfaces;
using Avaliacao.Net.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess
{
    public class ClienteDAOSQLServer : IClienteDAO
    {
        private SqlConnection conexao;

        public ClienteDAOSQLServer(SqlConnection conexao)
        {
            if(conexao == null)
            {
                throw new ArgumentNullException("conexao");
            }

            this.conexao = conexao;
        }
        
        public List<ClienteVO> BuscarClientes(string nome, TipoCliente? tipoCliente)
        {
            List<ClienteVO> clientes = new List<ClienteVO>();

            this.conexao.Open();
            SqlDataReader clientesReader = null;

            string selectTexto =
                @"select 
                ID_CLIENTE, EMAIL_CLIENTE, NOME_CLIENTE, TELEFONE_CLIENTE, TIPO_CLIENTE
                from
                CLIENTE
                where
                REMOVIDO = 0";

            SqlCommand selectComando = new SqlCommand(selectTexto, this.conexao);

            if (!string.IsNullOrEmpty(nome))
            {
                selectTexto += " and NOME_CLIENTE = @nomeCliente";
                SqlParameter nomeClienteParam = new SqlParameter("@nomeCliente", nome);
                selectComando.Parameters.Add(nomeClienteParam);
            }

            if (tipoCliente.HasValue)
            {
                selectTexto += " and TIPO_CLIENTE = @tipoCliente";
                SqlParameter tipoClienteParam = new SqlParameter("@tipoCliente", tipoCliente.Value.GetHashCode());
                selectComando.Parameters.Add(tipoClienteParam);
            }

            selectComando.Transaction = this.conexao.BeginTransaction();

            try
            {
                clientesReader = selectComando.ExecuteReader();

                if(clientesReader != null)
                {
                    while(clientesReader.Read())
                    {
                        ClienteVO cliente = new ClienteVO(Convert.ToInt32(clientesReader["ID_CLIENTE"]));
                        cliente.Email = clientesReader["EMAIL_CLIENTE"].ToString();
                        cliente.Nome = clientesReader["NOME_CLIENTE"].ToString();
                        cliente.Telefone = clientesReader["TELEFONE_CLIENTE"].ToString();
                        cliente.Tipo = (TipoCliente)Convert.ToInt32(clientesReader["TIPO_CLIENTE"]);
                        clientes.Add(cliente);
                    }
                }
            }
            catch
            {
                selectComando.Transaction.Rollback();
            }
            finally
            {
                if(clientesReader != null)
                {
                    clientesReader.Close();
                }
                selectComando.Transaction.Commit();
                this.conexao.Close();
            }

            return clientes;
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
