using asp.netcoreTelerikGrid.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages.Grid
{
    public class IndexModel : PageModel
    {
        public ProductViewModel products { get; set; }
        public void OnGet()
        {
        }
        public JsonResult OnPostReadRecords()
        {
            List<ProductViewModel> data = new List<ProductViewModel>();

            for (int i = 1; i <= 100; i++)
            {
                data.Add(new ProductViewModel()
                {
                    Id = i,
                    Name = "Name " + i.ToString(),
                    Description = "Address " + i.ToString(),
                    Created_at = DateTime.Now.AddHours(i)
                });
            }

            return new JsonResult(data);
        }

        public JsonResult OnPostUpdateRecord([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            System.Diagnostics.Debug.WriteLine("Updating");

            return new JsonResult(product);
        }
    }
}
