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

        public PedidoDAOSQLServer(SqlConnection conexao)
        {
            if(conexao == null)
            {
                throw new ArgumentNullException("conexao");
            }

            this.conexao = conexao;
        }

        public List<PedidoVO> BuscarPedidos(int? idCliente, DateTime? dataPedido)
        {
            string selectTexto =
                @"select
                    ID_PEDIDO, ID_CLIENTE, DATA_PEDIDO, DESCRICAO_PEDIDO, VALOR_PEDIDO
                  from
                    PEDIDO
                  ";

            if ((idCliente != null) || (dataPedido != null))
            {
                selectTexto += 
                    @"where
                        ";
            }

            List<SqlParameter> parametros = new List<SqlParameter>();

            if(idCliente != null)
            {
                selectTexto += "ID_CLIENTE = @idCliente ";
                parametros.Add(new SqlParameter("@idCliente", idCliente.Value));
            }

            if(dataPedido.HasValue)
            {
                // usando funções para pegar apenas a data (desprezar a hora)
                // e garantir que ambas datas estão no mesmo formato
                selectTexto += 
                    @"and CONVERT(NVARCHAR(10), CAST(CAST(DATA_PEDIDO AS DATE) AS DATETIME), 103) = 
                        CONVERT(NVARCHAR(10), CAST(CAST(@dataPedido AS DATE) AS DATETIME), 103)";
                parametros.Add(new SqlParameter("@dataPedido", dataPedido.Value));
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
                    int idPedido = Convert.ToInt32(pedidosReader["ID_PEDIDO"]);
                    DateTime dtPedido = Convert.ToDateTime(pedidosReader["DATA_PEDIDO"]);
                    ClienteVO clientePedido = new ClienteVO(Convert.ToInt32(pedidosReader["ID_CLIENTE"]));
                    
                    PedidoVO pedido = new PedidoVO(idPedido, dtPedido, clientePedido);
                    pedido.Descricao = pedidosReader["DESCRICAO_PEDIDO"].ToString();
                    pedido.Valor = Convert.ToDecimal(pedidosReader["VALOR_PEDIDO"]);

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
            throw new NotImplementedException();
        }

        public void RemoverPedido(int idPedido)
        {
            throw new NotImplementedException();
        }

        public void InserirPedido(PedidoVO pedido)
        {
            throw new NotImplementedException();
        }
    }
}
