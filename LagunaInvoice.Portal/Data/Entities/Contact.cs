using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public int DefaultTaxID { get; set; }

        public string Name { get; set; }

        public string PublicNote { get; set; }

        public string InvoicingStreet { get; set; }

        public string InvoicingCity { get; set; }

        public string InvoicingZIP { get; set; }

        public string IDNumber { get; set; }

        public string VATNumber { get; set; }

        public string Phone { get; set; }

        public string WWW { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company R_Company { get; set; }

        [ForeignKey("DefaultTaxID")]
        public virtual Tax R_DefaultTax { get; set; }

        public virtual ICollection<IssuedInvoice> C_IssuedInvoices { get; set; }
    }
}
