using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfrontadorNFSe
{
    public class ConnectionFactory
    {
        private readonly string _strConexao;
        public ConnectionFactory(string strConexao)
        {
            this._strConexao = strConexao;
        }

        public SqlConnection CreateAndOpenConnection()
        {
            var conexao = new SqlConnection(this._strConexao);
            conexao.Open();

            return conexao;
        }
    }
}
