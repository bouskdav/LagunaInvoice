using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class IssuedInvoiceItem
    {
        [Key]
        public int ID { get; set; }

        public int IsssuedInvoiceID { get; set; }

        public int? TaxID { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public string Units { get; set; }

        public decimal PriceVATExcl { get; set; }

        public decimal PriceVATPart { get; set; }

        public decimal PriceVATIncl { get; set; }

        [ForeignKey("TaxID")]
        public virtual Tax R_Tax { get; set; }

        [ForeignKey("IssuedInvoiceID")]
        public virtual IssuedInvoice R_Invoice { get; set; }
    }
}
