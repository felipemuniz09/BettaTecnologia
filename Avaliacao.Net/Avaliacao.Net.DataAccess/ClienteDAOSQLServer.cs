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

        private ClienteVO CriaCliente(SqlDataReader clienteReader)
        {
            ClienteVO cliente = new ClienteVO(Convert.ToInt32(clienteReader["ID_CLIENTE"]));
            cliente.Email = clienteReader["EMAIL_CLIENTE"].ToString();
            cliente.Nome = clienteReader["NOME_CLIENTE"].ToString();
            cliente.Telefone = clienteReader["TELEFONE_CLIENTE"].ToString();
            cliente.Tipo = (TipoCliente)Convert.ToInt32(clienteReader["TIPO_CLIENTE"]);

            return cliente;
        }

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

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(nome))
            {
                nome = string.Format("{0}{1}{0}", "%", nome);
                selectTexto += " and NOME_CLIENTE LIKE @nomeCliente";
                SqlParameter nomeClienteParam = new SqlParameter("@nomeCliente", nome);
                parametros.Add(nomeClienteParam);
            }

            if (tipoCliente.HasValue)
            {
                selectTexto += " and TIPO_CLIENTE = @tipoCliente";
                SqlParameter tipoClienteParam = new SqlParameter("@tipoCliente", tipoCliente.Value.GetHashCode());
                parametros.Add(tipoClienteParam);
            }

            SqlCommand selectComando = new SqlCommand(selectTexto, this.conexao);
            selectComando.Parameters.AddRange(parametros.ToArray());
            selectComando.Transaction = this.conexao.BeginTransaction();
            
            try
            {
                clientesReader = selectComando.ExecuteReader();

                if(clientesReader != null)
                {
                    while(clientesReader.Read())
                    {
                        ClienteVO cliente = this.CriaCliente(clientesReader);
                        clientes.Add(cliente);
                    }
                }

                if (clientesReader != null)
                {
                    clientesReader.Close();
                }

                selectComando.Transaction.Commit();
            }
            catch
            {
                // caso não tenha fechado no try
                if (clientesReader != null)
                {
                    clientesReader.Close();
                }

                selectComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }

            return clientes;
        }

        public ClienteVO BuscarCliente(int id)
        {
            ClienteVO cliente = new ClienteVO();

            string selectTexto =
                @"select 
                ID_CLIENTE, EMAIL_CLIENTE, NOME_CLIENTE, TELEFONE_CLIENTE, TIPO_CLIENTE
                from
                CLIENTE
                where
                ID_CLIENTE = @id";

            this.conexao.Open();

            SqlCommand selectComando = new SqlCommand(selectTexto, this.conexao);
            selectComando.Parameters.AddWithValue("@id", id);
            selectComando.Transaction = this.conexao.BeginTransaction();
            
            SqlDataReader clienteReader = null;

            try
            {
                clienteReader = selectComando.ExecuteReader();

                clienteReader.Read();

                cliente = this.CriaCliente(clienteReader);

                if (clienteReader != null)
                {
                    clienteReader.Close();
                }

                selectComando.Transaction.Commit();
            }
            catch
            {
                // caso não tenha fechado no try
                if (clienteReader != null)
                {
                    clienteReader.Close();
                }

                selectComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }

            return cliente;
        }

        public void AtualizarCliente(ClienteVO cliente)
        {
            string updateTexto =
                @"update
                    CLIENTE
                  set
                    EMAIL_CLIENTE = @emailCliente,
                    NOME_CLIENTE = @nomeCliente,
                    TELEFONE_CLIENTE = @telefoneCliente,
                    TIPO_CLIENTE = @tipoCliente
                  where
                    ID_CLIENTE = @idCliente";

            SqlCommand updateComando = new SqlCommand(updateTexto, this.conexao);
            updateComando.Parameters.AddWithValue("@emailCliente", cliente.Email);
            updateComando.Parameters.AddWithValue("@nomeCliente", cliente.Nome);
            updateComando.Parameters.AddWithValue("@telefoneCliente", cliente.Telefone);
            updateComando.Parameters.AddWithValue("@tipoCliente", cliente.Tipo.GetHashCode());
            updateComando.Parameters.AddWithValue("@idCliente", cliente.Id);

            this.conexao.Open();
            updateComando.Transaction = this.conexao.BeginTransaction();

            try
            {
                updateComando.ExecuteNonQuery();

                updateComando.Transaction.Commit();
            }
            catch
            {
                updateComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }
        }

        public void RemoverCliente(int idCliente)
        {
            string deleteTexto =
                 @"update
                     CLIENTE
                   set
                     REMOVIDO = 1
                   where
                     ID_CLIENTE = @idCliente";

            SqlCommand deleteComando = new SqlCommand(deleteTexto, this.conexao);
            deleteComando.Parameters.AddWithValue("@idCliente", idCliente);

            this.conexao.Open();
            deleteComando.Transaction = this.conexao.BeginTransaction();

            try
            {
                deleteComando.ExecuteNonQuery();

                deleteComando.Transaction.Commit();
            }
            catch
            {
                deleteComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }
        }

        public void InserirCliente(ClienteVO cliente)
        {
            string insertTexto =
                @"insert into CLIENTE(EMAIL_CLIENTE, NOME_CLIENTE, TELEFONE_CLIENTE, TIPO_CLIENTE)
                    values(@emailCliente, @nomeCliente, @telefoneCliente, @tipoCliente)";

            SqlCommand insertComando = new SqlCommand(insertTexto, this.conexao);
            insertComando.Parameters.AddWithValue("@emailCliente", cliente.Email);
            insertComando.Parameters.AddWithValue("@nomeCliente", cliente.Nome);
            insertComando.Parameters.AddWithValue("@telefoneCliente", cliente.Telefone);
            insertComando.Parameters.AddWithValue("@tipoCliente", cliente.Tipo.GetHashCode());

            this.conexao.Open();
            insertComando.Transaction = this.conexao.BeginTransaction();

            try
            {
                insertComando.ExecuteNonQuery();

                insertComando.Transaction.Commit();
            }
            catch
            {
                insertComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }
        }
    }
}
