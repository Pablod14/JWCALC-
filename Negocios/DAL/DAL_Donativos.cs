﻿using Negocios.EntityFramework;
using System.Linq;

namespace Negocios.Regras

{
    /// <summary>
    /// Classe para manipulação de dados da Entidade Donativos
    /// </summary>
    public class DAL_Donativos : IDALBaseCRUDEntity
    {
        /// <summary>
        /// Adicionar Donativo
        /// </summary>
        /// <param name="donativo">Entidade Donativo</param>
        public void AdicionarRegistro(DONATIVO donativo)
        {
            //Atualizando
            if (donativo.DONID != 0)
            {
                DONATIVO registro = baseDeDados.DONATIVO.First(x => x.DONID == donativo.DONID);
                registro = donativo;
            }
            //Inserindo Novo
            else
                baseDeDados.DONATIVO.Add(donativo);

            baseDeDados.SaveChanges();
        }
    }
}
