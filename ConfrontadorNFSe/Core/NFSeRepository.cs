using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfrontadorNFSe
{
    public class NFSeRepository
    {
        private readonly ConnectionFactory _connectionFactory; 

        public NFSeRepository(ConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;

        }

        public NFSe Salvar(NFSe nfse)
        {
            using (var conexao = this._connectionFactory.CreateAndOpenConnection())
            {
                var cmd = new SqlCommand(@"INSERT INTO [dbo].[NFSE](
                                                [numeroNFSe]
                                               ,[codigoVerificacao]
                                               ,[dataEmissao]
                                               ,[numeroRPS]
                                               ,[discriminacao]
                                               ,[numeroPedido]
                                               ,[documentoTomador]
                                               ,[nomeTomador]
                                               ,[valorNFSe]
                                               ,[valorISS])
                                         VALUES
                                               (@numeroNFSe
                                               ,@codigoVerificacao
                                               ,@dataEmissao
                                               ,@numeroRPS 
                                               ,@discriminacao  
                                               ,@numeroPedido  
                                               ,@documentoTomador 
                                               ,@nomeTomador  
                                               ,@valorNFSe  
                                               ,@valorISS)", conexao);

                cmd.Parameters.AddWithValue("@numeroNFSe", nfse.NumeroNFSe);
                cmd.Parameters.AddWithValue("@codigoVerificacao", nfse.CodigoVerificacao);
                cmd.Parameters.AddWithValue("@dataEmissao", nfse.DataEmissao);
                cmd.Parameters.AddWithValue("@numeroRPS", nfse.NumeroRPS);
                cmd.Parameters.AddWithValue("@discriminacao", nfse.Discriminacao);
                cmd.Parameters.AddWithValue("@numeroPedido", nfse.NumeroPedido);
                cmd.Parameters.AddWithValue("@documentoTomador", nfse.DocumentoTomador);
                cmd.Parameters.AddWithValue("@nomeTomador", nfse.NomeTomador);
                cmd.Parameters.AddWithValue("@valorNFSe", nfse.ValorNFSe);
                cmd.Parameters.AddWithValue("@valorISS", nfse.ValorISS);

                cmd.ExecuteNonQuery();

            }
            return nfse;
        }
    }
     
}
