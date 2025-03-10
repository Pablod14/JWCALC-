﻿using Negocios.EntityFramework.DML.ACESSOS;
using System.Linq;

namespace Negocios.DAL
{
    public class DAL_Usuarios
    {
        #region Campos
        internal readonly BaseACESSOS baseDeDados;
        #endregion

        public DAL_Usuarios()
        {
            baseDeDados = new BaseACESSOS();
        }

        public void AdicionarRegistro(USUARIOS usuarios)
        {
            //Atualizando
            if (usuarios.USUID != 0)
            {
                USUARIOS registro = baseDeDados.USUARIOS.First(x => x.USUID == usuarios.USUID);
                registro = usuarios;
            }
            //Inserindo Novo
            else
                baseDeDados.USUARIOS.Add(usuarios);

            baseDeDados.SaveChanges();
        }

        public bool ValidaUsuarioLogin(USUARIOS usuario)
        {
            if (usuario != null && !string.IsNullOrEmpty(usuario?.USUNOME))
            {
                USUARIOS usuarioLogin = (from u in baseDeDados.USUARIOS 
                                         where u.USUNOME.ToUpper() == usuario.USUNOME.ToUpper() && u.USUSENHA.ToUpper() == usuario.USUSENHA.ToUpper()
                                         select u).FirstOrDefault();

                return usuarioLogin != null;
            }
            else
                return false;
        }

        public bool VerificaUsuarioExistente(string pNomeUsuario)
        {
            return !baseDeDados.USUARIOS.All(x => x.USUNOME.ToUpper() != pNomeUsuario.ToUpper());
        }
    }
}