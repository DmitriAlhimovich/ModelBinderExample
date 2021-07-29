using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinderExample.Controllers
{
    public class ProductsWithBindPropertyController : Controller
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public string GetById()
        {
            return $"Product {Id}";
        }

        public string GetByIdWithQuery(bool includeDescription)
        {
            return $"Product {Id}" + (includeDescription ? " with description" : string.Empty);
        }
    }
}
