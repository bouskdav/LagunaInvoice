using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class ApplicationUserCompany
    {
        public string ApplicationUserID { get; set; }

        public int CompanyID { get; set; }

        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser R_ApplicationUser { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company R_Company { get; set; }
    }
}
