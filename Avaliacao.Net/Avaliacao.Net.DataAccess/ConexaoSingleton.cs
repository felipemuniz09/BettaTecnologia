using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Net.DataAccess
{
    public static class ConexaoSingleton
    {
       private static SqlConnection conexao;

       public static SqlConnection Conexao
       {
          get 
          {
             if (conexao == null)
             {
                conexao = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BettaDB.mdf;Integrated Security=True");
             }
             return conexao;
          }
       }
    }
}