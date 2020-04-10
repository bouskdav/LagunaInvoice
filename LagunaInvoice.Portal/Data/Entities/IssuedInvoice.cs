using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class IssuedInvoice
    {
        [Key]
        public int ID { get; set; }

        public int ContactID { get; set; }

        public string InvoiceNumber { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateIssued { get; set; }

        public DateTime DateDue { get; set; }

        public DateTime DateVAT { get; set; }

        public string NotePublic { get; set; }

        public string NoteInternal { get; set; }

        public string Footer { get; set; }

        public virtual ICollection<IssuedInvoiceItem> C_InvoiceItems { get; set; }

        public virtual ICollection<IssuedInvoicePayment> C_InvoicePayments { get; set; }

        [ForeignKey("ContactID")]
        public virtual Contact R_Contact { get; set; }

        public decimal TotalVATExcl => 0;

        public decimal TotalVATPart => 0;

        public decimal TotalVATIncl => 0;
    }
}
