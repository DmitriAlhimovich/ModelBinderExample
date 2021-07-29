using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBinderExample.Models;

namespace ModelBinderExample.Controllers
{
    public class ProductsController : Controller
    {
        public string GetById(int id)
        {
            return $"Product {id}";
        }

        public string GetByIdWithQuery(int id, bool includeDescription)
        {
            return $"Product {id}" + (includeDescription ? " with description" : string.Empty);
        }

        public string GetByIdFromQuery([FromQuery]string id)
        {
            return $"Product {id}";
        }

        public string Edit(Product product)
        {
            return $"Edit product. {JsonSerializer.Serialize(product)}";
        }

        public string EditWithDiscount(ProductWithDiscount product)
        {
            return $"Edit product with discount. {JsonSerializer.Serialize(product)}";
        }
    }
}
