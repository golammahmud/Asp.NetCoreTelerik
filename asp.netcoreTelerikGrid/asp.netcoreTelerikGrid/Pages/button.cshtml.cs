using asp.netcoreTelerikGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages
{
    public class buttonModel : PageModel
    {
        [BindProperty]
       public Student student { get; set; }
        public void OnGet()
        {
        }
    }
}
