﻿using Negocios.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Negocios.Regras

{
    /// <summary>
    /// Classe para manipulação de dados da Entidade Donativos
    /// </summary>
    public class DAL_TipoRecibos : IDALBaseCRUDEntity
    {
        /// <summary>
        /// Adicionar Donativo
        /// </summary>
        /// <param name="donativo">Entidade Donativo</param>
        public void AdicionarRegistro(TIPORECIBO tipoRecibos)
        {
            //Atualizando
            if (tipoRecibos.TIPID != 0)
            {
                TIPORECIBO registro = baseDeDados.TIPORECIBO.First(x => x.TIPID == tipoRecibos.TIPID);
                registro = tipoRecibos;
            }
            //Inserindo Novo
            else
                baseDeDados.TIPORECIBO.Add(tipoRecibos);

            baseDeDados.SaveChanges();
        }

        public List<TIPORECIBO> ConsultarRegistros()
        {
            return baseDeDados.TIPORECIBO.ToList();
        }
    }
}
