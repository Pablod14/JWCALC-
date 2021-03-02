using Negocios.ConexaoBD;
using System.Collections.Generic;
using System.Data;

namespace Negocios.Regras
{
    /// <summary>
    /// Classe que contém métodos básicos de Inserção/Consultas no BD
    /// </summary>
    internal class BaseTransacoes
    {
        #region Campos
        private readonly TransacoesBD transacoes;
        #endregion

        public BaseTransacoes(string pNomeDataBase, int pTimeout = 30, bool pMontarConexaoConstrutor = true)
        {
            transacoes = new TransacoesBD(pNomeDataBase, pTimeout, pMontarConexaoConstrutor);
        }

        /// <summary>
        /// Indica o uso de Commit/Roolback na transação
        /// </summary>
        internal void UsaCommitRollback()
        {
            transacoes.UsaCommitRollback();
        }

        /// <summary>
        /// Chama a procedure que inclui registros no Banco de Dados
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pLinhasAfetadas">Retorna o número de linhas afetadas.</param>
        internal void GravaRegistro(string pNomeProcedure, ref List<object> pParametros, out int pLinhasAfetadas)
        {
            transacoes.GravaRegistro(pNomeProcedure, ref pParametros, false, out pLinhasAfetadas);
        }

        /// <summary>
        /// Chama a procedure que inclui registros no Banco de Dados
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pRetornaIDInserido">Retorna o ID da inclusão do registro</param>
        /// <param name="pLinhasAfetadas">Retorna o número de linhas afetadas.</param>
        internal void GravaRegistro(string pNomeProcedure, ref List<object> pParametros, bool pRetornaIDInserido, out int pLinhasAfetadas)
        {
            transacoes.GravaRegistro(pNomeProcedure, ref pParametros, pRetornaIDInserido, out pLinhasAfetadas);
        }

        /// <summary>
        /// Chama a procedure que retorna dados.
        /// </summary>
        /// <param name="pNomeProcedure">Nome da Procedure a ser executada</param>
        /// <param name="pParametros">Lista de Parâmetros</param>
        /// <param name="pObterApenasPrimeiraLinhaColuna">Retorna o registro da Primeira célula da consulta.</param>
        /// <returns>DataSet com Registros</returns>
        internal DataSet ObterRegistros(string pNomeProcedure, ref List<object> pParametros, bool pObterApenasPrimeiraLinhaColuna = false)
        {
            return transacoes.ObterRegistros(pNomeProcedure, ref pParametros, pObterApenasPrimeiraLinhaColuna);
        }
    }
}
