using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JWCalc.Models
{
    public class Login
    {
        [Display(Name = "Nome de Usuário")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o usuário")]
        [StringLength(20)]        
        public string USUARIO { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [StringLength(20)]
        public string SENHA { get; set; }
    }
}