using Negocios.EntityFramework;
using System;

namespace Negocios
{
    /// <summary>
    /// Classe Base para as Operações de Persistência em BD do Entity Framework
    /// </summary>
    public class IDALBaseCRUDEntity : IDisposable
    {
        #region Campos
        internal Entities baseDeDados;
        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public IDALBaseCRUDEntity()
        {
            if (baseDeDados == null)
                baseDeDados = new Entities();
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
