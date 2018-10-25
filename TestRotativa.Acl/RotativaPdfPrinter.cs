using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace TestRotativa.Acl
{
    public class RotativaPdfPrinter : IPdfPrinter
    {
        public RotativaPdfPrinter(IHostingEnvironment environment)
        {
            RotativaConfiguration.Setup(environment);
        }

        public Task<byte[]> PrintPdf(ActionContext context, string viewName, object model)
        {
            var view = new ViewAsPdf(
                viewName: viewName, 
                model: model);

            return view.BuildFile(context);
        }
    }
}
