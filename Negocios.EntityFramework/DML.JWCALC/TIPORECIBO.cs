namespace Negocios.EntityFramework.DML.JWCALC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TIPORECIBO
    {
        [Key]
        public int TIPID { get; set; }
        public int TIPCOD { get; set; }
        public string TIPDESC { get; set; }
    }
}
