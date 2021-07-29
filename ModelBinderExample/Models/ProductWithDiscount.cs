using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBinderExample.Models
{
    [ModelBinder(typeof(ProductDiscountBinder))]
    public class ProductWithDiscount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

    }

    public class ProductDiscountBinder : IModelBinder
    {
        private const decimal DiscountRate = 0.3m;

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var id = bindingContext.ValueProvider.GetValue("id").FirstValue;
            var title = bindingContext.ValueProvider.GetValue("title").FirstValue;
            var price = bindingContext.ValueProvider.GetValue("price").FirstValue
                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            var priceWithDiscount = decimal.Parse(price ?? "0", NumberStyles.Any) * (1 - DiscountRate);

            bindingContext.Result = ModelBindingResult.Success(new ProductWithDiscount()
            {
                Id = int.Parse(id ?? "0"),
                Title = title,
                Price = priceWithDiscount
            });
            return Task.CompletedTask;
        }
    }
}
