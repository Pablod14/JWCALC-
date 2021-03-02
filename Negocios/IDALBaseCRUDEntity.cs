using Negocios.EntityFramework.DML.ACESSOS;
using System;

namespace Negocios
{
    /// <summary>
    /// Classe Base para as Operações de Persistência em BD do Entity Framework
    /// </summary>
    public class IDALBaseCRUDEntity : IDisposable
    {
        #region Campos
        internal readonly BaseACESSOS baseDeDados;
        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public IDALBaseCRUDEntity(string pNomeBase)
        {
            if (baseDeDados == null)
                baseDeDados = new BaseACESSOS(pNomeBase);
        }

        /// <summary>
        /// Libera a conexão com a Base após o uso
        /// </summary>
        public void Dispose()
        {
            baseDeDados.Dispose();
        }
    }
}
