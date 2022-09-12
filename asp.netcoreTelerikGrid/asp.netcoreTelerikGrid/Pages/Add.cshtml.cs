using asp.netcoreTelerikGrid.Data;
using asp.netcoreTelerikGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.netcoreTelerikGrid.Pages
{
    public class AddModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDbContext applicationDbContext;

        public AddModel(ILogger<IndexModel> logger, ApplicationDbContext _applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = _applicationDbContext;
        }

        [BindProperty]
        public List<string> StudentList { get; set; }

        [BindProperty]
        public Student Students { get; set; }

        public void OnGet()
        {
            Students = new Student();
        }

        public IActionResult OnPost()
        {

            Students.IsStudied = string.Join(",", StudentList);


            if (ModelState.IsValid)
            {
                applicationDbContext.Student.Add(Students);
                applicationDbContext.SaveChanges();
            }
            return Page();



        }
    }
}
