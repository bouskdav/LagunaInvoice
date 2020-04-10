using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class Company
    {
        [Key]
        public int ID { get; set; }

        public virtual ICollection<IssuedInvoice> C_IssuedInvoices { get; set; }

        public virtual ICollection<ApplicationUserCompany> C_UserCompanies { get; set; }

        public virtual ICollection<Contact> C_Contacts { get; set; }
    }
}
