using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Negocios.ConexaoBD
{
    /// <summary>
    /// Herança de IDisposable para sempre executar o método de fechar a conexão com o BD no método Dispose()
    /// </summary>
    internal class Conexao : IDisposable
    {
        #region Campos
        private SqlConnection conexao = new SqlConnection();
        private SqlTransaction transacao;
        bool UsouBeginTran = false;
        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="pTimeOut">TimeOut da Conexao.</param>
        /// <param name="pMontarConexaoConstrutor">Indica se a string de conexão deve ser montada pelo construtor.</param>
        public Conexao(string pNomeDataBase, int pTimeOut, bool pMontarConexaoConstrutor)
        {
            if (pMontarConexaoConstrutor)
                this.MontarConexao(pNomeDataBase, pTimeOut);
        }

        /// <summary>
        /// Retorna a String de Conexão
        /// </summary>
        /// <param name="pTimeOut">TimeOut da Conexao.</param>
        private void MontarConexao(string pNomeDataBase, int pTimeOut)
        {
            conexao = new SqlConnection(new ConnectionString_ADO(pNomeDataBase, pTimeOut).RetornaStringConexao());

            if (conexao.State == ConnectionState.Open)
                conexao.Close();

            conexao.Open();
        }

        /// <summary>
        /// Encerra a Conexão
        /// </summary>
        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        /// <summary>
        /// Chama a procedure que inclui registros no Banco de Dados
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pRetornaIDInserido">Retorna o ID da inclusão do registro</param>
        /// <param name="pLinhasAfetadas">Retorna o número de linhas afetadas.</param>
        public void GravarRegistro(string pNomeProcedure, ref List<object> pParametros, bool pRetornaIDInserido, out int pLinhasAfetadas)
        {
            pLinhasAfetadas = 0;

            if (conexao.State != ConnectionState.Open)
                conexao.Open();

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand(pNomeProcedure, conexao, transacao);
                pParametros?.ForEach(x => cmd.Parameters.Add(x.ToString()));

                pLinhasAfetadas = cmd.ExecuteNonQuery();

                if (UsouBeginTran)
                    transacao.Commit();
            }
            catch
            {
                //Ver como vai tratar aqui.
                if (UsouBeginTran)
                    transacao.Rollback();
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// Chama a procedure que retorna dados.
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pObterApenasPrimeiraLinhaColuna">Retorna o registro da Primeira célula da consulta.</param>
        /// <returns>DataSet com Registros</returns>
        public DataSet ObterRegistros(string pNomeProcedure, ref List<object> pParametros, bool pObterApenasPrimeiraLinhaColuna)
        {
            if (conexao.State != ConnectionState.Open)
                conexao.Open();

            DataSet retorno = new DataSet();

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand(pNomeProcedure, conexao, transacao);
                pParametros?.ForEach(x => cmd.Parameters.Add(x.ToString()));

                if (!pObterApenasPrimeiraLinhaColuna)
                    new SqlDataAdapter(cmd.CommandText, conexao).Fill(retorno);
                else
                    retorno = (DataSet)cmd.ExecuteScalar();
            }
            catch
            {
                //Ver como vai tratar aqui.
                retorno = null;
            }
            finally
            {
                this.Dispose();
            }

            return retorno;
        }

        /// <summary>
        /// Indica o uso de Commit/Roolback na transação
        /// </summary>
        public void UsaCommitRollback()
        {
            UsouBeginTran = true;
            transacao = conexao.BeginTransaction();
        }
    }
}