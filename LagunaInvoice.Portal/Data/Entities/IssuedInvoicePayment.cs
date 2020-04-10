using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class IssuedInvoicePayment
    {
        [Key]
        public int ID { get; set; }

        public int IssuedInvoiceID { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Note { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("IssuedInvoiceID")]
        public virtual IssuedInvoice R_Invoice { get; set; }
    }
}
