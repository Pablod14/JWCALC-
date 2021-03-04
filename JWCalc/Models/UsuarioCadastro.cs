using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWCalc.Models
{
    public class UsuarioCadastro
    {
        [Display(Name = "Nome de Usuário")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o usuário")]
        [StringLength(20)]
        [Remote("UsuarioExistente", "Usuarios", ErrorMessage = "O Usuário informado já existe")]
        public string NOME { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [StringLength(20)]
        public string SENHA { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [StringLength(20)]
        [System.ComponentModel.DataAnnotations.Compare("SENHA", ErrorMessage = "As senhas digitadas não são iguais")]
        public string CONFIRMSENHA { get; set; }
    }
}