namespace Negocios.EntityFramework.DML.JWCALC
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RECIBO
    {
        public RECIBO()
        {
            this.ENTRADASDONATIVO = new HashSet<ENTRADASDONATIVO>();
        }
    
        [Key]
        public int RECID { get; set; }
        public decimal RECTOTAL { get; set; }
        public string RECASSINADOPOR { get; set; }
        public string RECCONFERIDOPOR { get; set; }
        public bool RECSEGUNDAVIA { get; set; }
        public int RECTIPODONATIVO { get; set; }
        public System.DateTime RECDATA { get; set; }
    
        public virtual ICollection<ENTRADASDONATIVO> ENTRADASDONATIVO { get; set; }
        public virtual TIPODONATIVO TIPODONATIVO { get; set; }
    }
}
