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
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            RotativaConfiguration.Setup(environment);
        }

        public Task<byte[]> PrintPdf(ActionContext context, string viewName, object model)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(viewName))
            {
                throw new ArgumentException("The view name cannot be empty", nameof(viewName));
            }

            var view = new ViewAsPdf(
                viewName: viewName, 
                model: model);

            return view.BuildFile(context);
        }
    }
}
