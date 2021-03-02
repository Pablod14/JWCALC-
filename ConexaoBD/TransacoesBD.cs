using System.Collections.Generic;
using System.Data;

namespace Negocios.ConexaoBD
{
    /// <summary>
    /// Classe que contém métodos básicos de Inserção/Consultas no BD
    /// </summary>
    public class TransacoesBD
    {
        #region Campos
        private readonly Conexao conexao;
        private readonly int TimeOut;
        private readonly string NomeDataBase;
        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="pTimeout">TimeOut da Conexao</param>
        /// <param name="pMontarConexaoConstrutor">Indica se a string de conexão deve ser montada pelo construtor</param>
        public TransacoesBD(string pNomeDataBase, int pTimeout = 30, bool pMontarConexaoConstrutor = true)
        {
            NomeDataBase = pNomeDataBase;
            TimeOut = pTimeout;
            conexao = new Conexao(pNomeDataBase, TimeOut, pMontarConexaoConstrutor);
        }

        /// <summary>
        /// Retornar a String de Conexão
        /// </summary>
        /// <typeparam name="T">Tipo ConnectionString_ADO ou ConnectionString_EntityFramework.</typeparam>
        /// <returns>String de Conexão</returns>
        public string StringDeConexao()
        {
            return new BaseConnectionString(NomeDataBase, TimeOut).RetornaStringConexao();
        }

        /// <summary>
        /// Indica o uso de Commit/Roolback na transação
        /// </summary>
        public void UsaCommitRollback()
        {
            conexao.UsaCommitRollback();
        }

        /// <summary>
        /// Chama a procedure que inclui registros no Banco de Dados
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pLinhasAfetadas">Retorna o número de linhas afetadas.</param>
        public void GravaRegistro(string pNomeProcedure, ref List<object> pParametros, out int pLinhasAfetadas)
        {
            this.GravaRegistro(pNomeProcedure, ref pParametros, false, out pLinhasAfetadas);
        }

        /// <summary>
        /// Chama a procedure que inclui registros no Banco de Dados
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pRetornaIDInserido">Retorna o ID da inclusão do registro</param>
        /// <param name="pLinhasAfetadas">Retorna o número de linhas afetadas.</param>
        public void GravaRegistro(string pNomeProcedure, ref List<object> pParametros, bool pRetornaIDInserido, out int pLinhasAfetadas)
        {
            using (conexao)
            {
                conexao.GravarRegistro(pNomeProcedure, ref pParametros, pRetornaIDInserido, out pLinhasAfetadas);
            }
        }

        /// <summary>
        /// Chama a procedure que retorna dados.
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pObterApenasPrimeiraLinhaColuna">Retorna o registro da Primeira célula da consulta.</param>
        /// <returns>DataSet com Registros</returns>
        public DataSet ObterRegistros(string pNomeProcedure, ref List<object> pParametros, bool pObterApenasPrimeiraLinhaColuna = false)
        {
            DataSet retorno = new DataSet();

            using (conexao)
            {
                retorno = conexao.ObterRegistros(pNomeProcedure, ref pParametros, pObterApenasPrimeiraLinhaColuna);
            }

            return retorno;
        }

    }
}
