using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using TestRotativa.Acl;
using TestRotativa.Models.Pdf;

namespace TestRotativa.Controllers
{
    public class PdfController : Controller
    {
        private readonly IPdfPrinter _pdfPrinter;

        public PdfController(IPdfPrinter pdfPrinter)
        {
            _pdfPrinter = pdfPrinter ?? throw new ArgumentNullException(nameof(pdfPrinter));
        }

        public async Task<IActionResult> Invoice()
        {
            var viewModel = BuildInvoiceViewModel();
            var fileContents = await _pdfPrinter.PrintPdf(ControllerContext, nameof(Invoice), viewModel);

            return File(fileContents, "application/pdf");
        }

        private InvoiceViewModel BuildInvoiceViewModel()
        {
            return new InvoiceViewModel
            {
                Currency = "EUR",
                Customer = new InvoiceViewModel.PartyInfo
                {
                    Address = new InvoiceViewModel.AddressDescriptor
                    {
                        Address = "via di Prova 123",
                        City = "Brescia",
                        PostalCode = "25100",
                        Province = "BS"
                    },
                    Name = "UnCliente srl",
                    NationalIdentificationNumber = "12345678900",
                    VatNumber = "IT12345678900"
                },
                Date = DateTime.Today,
                LineItems = new InvoiceViewModel.LineItem[]
                {
                    new InvoiceViewModel.LineItem
                    {
                        Code = "CL001",
                        Description = "Attività di consulenza e sviluppo per un progetto a caso",
                        Quantity = 1,
                        UnitPrice = 3000,
                        TotalPrice = 3000,
                        Vat = 20
                    }
                },
                Number = "1/2018",
                Supplier = new InvoiceViewModel.PartyInfo
                {
                    Address = new InvoiceViewModel.AddressDescriptor
                    {
                        Address = "via Mantova 106",
                        City = "Montichiari",
                        PostalCode = "25018",
                        Province = "BS"
                    },
                    Name = "Alberto Mori",
                    NationalIdentificationNumber = "MROLRT87M24B157G",
                    VatNumber = "IT03494270980"
                },
                TaxableAmount = 3000,
                Taxes = 600,
                TotalPrice = 3600
            };
        }
    }
}