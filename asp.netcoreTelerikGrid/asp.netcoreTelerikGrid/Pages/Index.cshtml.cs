using asp.netcoreTelerikGrid.Data;
using asp.netcoreTelerikGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDbContext applicationDbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext _applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = _applicationDbContext;
        }

     

    

        [BindProperty]
        public IList<Student> StudentsList { get; set; }

        [BindProperty]
        public List<string> DropdownSelector { get; set; }
        public void OnGet()
        {
            StudentsList = applicationDbContext.Student.ToList();




        }

      
    }
}