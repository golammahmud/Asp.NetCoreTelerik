using asp.netcoreTelerikGrid.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages.Grid
{
    public class ListModel : PageModel
    {
        public static IList<ProductViewModel> product;

        public void OnGet()
        {
            if (product == null)
            {
                product = new List<ProductViewModel>();

                Enumerable.Range(1, 50).ToList().ForEach(i => product.Add(new ProductViewModel
                {
                    Id= i,
                    Created_at = DateTime.Now.AddDays(i % 7),
                    price = i * 10,
                    Name = "ShipName " + i,
                    Description = "ShipCity " + i
                }));

            }          
        }
        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            return new JsonResult(product.ToDataSourceResult(request));
        }

        public JsonResult OnPostCreate([DataSourceRequest] DataSourceRequest request, ProductViewModel order)
        {
            order.Id = product.Count + 2;
            product.Add(order);

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, ProductViewModel order)
        {
            product.Where(x => x.Id == order.Id).Select(x => order);

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, ProductViewModel order)
        {
            product.Remove(product.FirstOrDefault(x => x.Id == order.Id));

            return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        }



        [HttpPost]
        public ActionResult OnPostSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

    }
}
