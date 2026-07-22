using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Common
{
    internal class clsInvoice
    {
        // Invoice number
        // Invoice date
        // Total cost
        // List <clsItems>

        public string InvoiceNum { get; set; }

        public string InvoiceDate { get; set; }

        public string TotalCost { get; set; }

        // Hold the list of items that correspond to a particular invoice
        public List<clsItem> ItemsList { get; set; } 
    }
}
