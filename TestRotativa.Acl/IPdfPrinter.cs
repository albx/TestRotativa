using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestRotativa.Acl
{
    public interface IPdfPrinter
    {
        Task<byte[]> PrintPdf(ActionContext context, string viewName, object model);
    }
}
