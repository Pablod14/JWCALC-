namespace Negocios.EntityFramework.DML.JWCALC
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TIPODONATIVO
    {        public TIPODONATIVO()
        {
            this.DONATIVO = new HashSet<DONATIVO>();
            this.RECIBO = new HashSet<RECIBO>();
        }
    
        [Key]
        public int TIPID { get; set; }
        public int TIPCOD { get; set; }
        public string TIPDESC { get; set; }
            public virtual ICollection<DONATIVO> DONATIVO { get; set; }

        public virtual ICollection<RECIBO> RECIBO { get; set; }
    }
}
