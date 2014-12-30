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
    public class PedidoDAOSQLServer : IPedidoDAO
    {
        private SqlConnection conexao;

        private PedidoVO CriaPedido(SqlDataReader pedidoReader)
        {
            int idPedido = Convert.ToInt32(pedidoReader["ID_PEDIDO"]);
            DateTime dtPedido = Convert.ToDateTime(pedidoReader["DATA_PEDIDO"]);
            ClienteVO clientePedido = new ClienteVO(Convert.ToInt32(pedidoReader["ID_CLIENTE"]));
            clientePedido.Nome = pedidoReader["NOME_CLIENTE"].ToString();
            PedidoVO pedido = new PedidoVO(idPedido, dtPedido, clientePedido);
            pedido.Descricao = pedidoReader["DESCRICAO_PEDIDO"].ToString();
            pedido.Valor = Convert.ToDecimal(pedidoReader["VALOR_PEDIDO"]);

            return pedido;
        }

        public PedidoDAOSQLServer(SqlConnection conexao)
        {
            if(conexao == null)
            {
                throw new ArgumentNullException("conexao");
            }

            this.conexao = conexao;
        }

        public List<PedidoVO> BuscarPedidos(string nomeCliente, DateTime? dtInicialPedido, DateTime? dtFinalPedido)
        {
            string selectTexto =
                @"select
                    ID_PEDIDO, P.ID_CLIENTE as ID_CLIENTE, DATA_PEDIDO, DESCRICAO_PEDIDO, VALOR_PEDIDO, NOME_CLIENTE
                  from
                    PEDIDO P join CLIENTE C on P.ID_CLIENTE = C.ID_CLIENTE
                  ";

            if ((!string.IsNullOrEmpty(nomeCliente)) || (dtInicialPedido != null) || (dtInicialPedido != null))
            {
                selectTexto += 
                    @"where
                        ";
            }

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(nomeCliente))
            {
                selectTexto += "C.NOME_CLIENTE = @nomeCliente ";
                parametros.Add(new SqlParameter("@nomeCliente", nomeCliente));
            }

            if (dtInicialPedido.HasValue)
            {
                // usando funções para pegar apenas a data (desprezar a hora)
                // e garantir que ambas datas estão no mesmo formato
                selectTexto += 
                    @"and CONVERT(NVARCHAR(10), CAST(CAST(P.DATA_PEDIDO AS DATE) AS DATETIME), 103) >= 
                        CONVERT(NVARCHAR(10), CAST(CAST(@dtInicialPedido AS DATE) AS DATETIME), 103)";
                parametros.Add(new SqlParameter("@dataPedido", dtInicialPedido.Value));
            }

            if (dtFinalPedido.HasValue)
            {
                // usando funções para pegar apenas a data (desprezar a hora)
                // e garantir que ambas datas estão no mesmo formato
                selectTexto +=
                    @"and CONVERT(NVARCHAR(10), CAST(CAST(P.DATA_PEDIDO AS DATE) AS DATETIME), 103) <= 
                        CONVERT(NVARCHAR(10), CAST(CAST(@dtFinalPedido AS DATE) AS DATETIME), 103)";
                parametros.Add(new SqlParameter("@dataPedido", dtFinalPedido.Value));
            }

            SqlCommand selectComando = new SqlCommand(selectTexto, this.conexao);
            selectComando.Parameters.AddRange(parametros.ToArray());

            this.conexao.Open();
            selectComando.Transaction = this.conexao.BeginTransaction();
            SqlDataReader pedidosReader = null;
            List<PedidoVO> pedidos = new List<PedidoVO>();

            try
            {
                pedidosReader = selectComando.ExecuteReader();

                while(pedidosReader.Read())
                {
                    PedidoVO pedido = this.CriaPedido(pedidosReader);

                    pedidos.Add(pedido);
                }

                if(pedidosReader != null)
                {
                    pedidosReader.Close();
                }

                selectComando.Transaction.Commit();
            }
            catch
            {
                // caso não tenha fechado no try
                if (pedidosReader != null)
                {
                    pedidosReader.Close();
                }

                selectComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }

            return pedidos;
        }

        public void AtualizarPedido(PedidoVO pedido)
        {
            // não atualiza data, cliente nem id
            string updateTexto =
                @"update
                    PEDIDO
                  set
                    DESCRICAO_PEDIDO = @descricao,
                    VALOR_PEDIDO = @valor
                  where
                    ID_PEDIDO = @idPedido";

            SqlCommand updateComando = new SqlCommand(updateTexto, this.conexao);
            updateComando.Parameters.AddWithValue("@descricao", pedido.Descricao);
            updateComando.Parameters.AddWithValue("@valor", pedido.Valor);
            updateComando.Parameters.AddWithValue("@idPedido", pedido.Id);

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

        public void RemoverPedido(int idPedido)
        {
            string deleteTexto =
                @"delete
                    PEDIDO
                  where
                    ID_PEDIDO = @idPedido";

            SqlCommand deleteComando = new SqlCommand(deleteTexto, this.conexao);
            deleteComando.Parameters.AddWithValue("@idPedido", idPedido);

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

        public void InserirPedido(PedidoVO pedido)
        {
            string insertTexto =
                @"insert into PEDIDO(ID_CLIENTE, DESCRICAO_PEDIDO, VALOR_PEDIDO)
                    values(@idCliente, @descricaoPedido, @valorPedido)";

            SqlCommand insertComando = new SqlCommand(insertTexto, this.conexao);
            insertComando.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
            insertComando.Parameters.AddWithValue("@descricaoPedido", pedido.Descricao);
            insertComando.Parameters.AddWithValue("@valorPedido", pedido.Valor);

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

        public PedidoVO BuscarPedido(int id)
        {
            string selectTexto =
                @"select
                    ID_PEDIDO, P.ID_CLIENTE as ID_CLIENTE, DATA_PEDIDO, DESCRICAO_PEDIDO, VALOR_PEDIDO, NOME_CLIENTE
                  from
                    PEDIDO P join CLIENTE C on P.ID_CLIENTE = C.ID_CLIENTE
                  where
                    ID_PEDIDO = @idPedido";

            this.conexao.Open();

            SqlCommand selectComando = new SqlCommand(selectTexto, this.conexao);
            selectComando.Parameters.AddWithValue("@idPedido", id);
            selectComando.Transaction = this.conexao.BeginTransaction();

            SqlDataReader pedidoReader = null;
            PedidoVO pedido = new PedidoVO();

            try
            {
                pedidoReader = selectComando.ExecuteReader();

                pedidoReader.Read();

                pedido = this.CriaPedido(pedidoReader);

                if (pedidoReader != null)
                {
                    pedidoReader.Close();
                }

                selectComando.Transaction.Commit();
            }
            catch
            {
                // caso não tenha fechado no try
                if (pedidoReader != null)
                {
                    pedidoReader.Close();
                }

                selectComando.Transaction.Rollback();
            }
            finally
            {
                this.conexao.Close();
            }

            return pedido;
        }
    }
}
