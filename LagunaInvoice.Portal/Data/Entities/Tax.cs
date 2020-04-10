using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LagunaInvoice.Portal.Data.Entities
{
    public class Tax
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }
    }
}
