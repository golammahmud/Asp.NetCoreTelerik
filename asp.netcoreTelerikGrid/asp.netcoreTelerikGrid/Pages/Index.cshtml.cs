using asp.netcoreTelerikGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public Student   Students { get; set; }
        public void OnGet()
        {
            Students = new Student();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}