using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRotativa.Models.Pdf
{
    public class InvoiceViewModel
    {
        public string Number { get; set; }

        public string Currency { get; set; }

        public PartyInfo Customer { get; set; }

        public PartyInfo Supplier { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<LineItem> LineItems { get; set; }

        public decimal TaxableAmount { get; set; }

        public decimal Taxes { get; set; }

        public decimal TotalPrice { get; set; }

        public class LineItem
        {
            public string Code { get; set; }

            public string Description { get; set; }

            public int Quantity { get; set; }

            public decimal UnitPrice { get; set; }

            public decimal TotalPrice { get; set; }

            public decimal Vat { get; set; }
        }
        
        public class PartyInfo
        {
            public string Name { get; set; }

            public AddressDescriptor Address { get; set; }

            public string NationalIdentificationNumber { get; set; }

            public string VatNumber { get; set; }
        }

        public class AddressDescriptor
        {
            public string Address { get; set; }

            public string City { get; set; }

            public string PostalCode { get; set; }

            public string Province { get; set; }
        }
    }
}
