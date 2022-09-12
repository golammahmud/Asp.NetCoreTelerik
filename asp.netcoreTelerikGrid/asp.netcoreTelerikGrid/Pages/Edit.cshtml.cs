using asp.netcoreTelerikGrid.Data;
using asp.netcoreTelerikGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace asp.netcoreTelerikGrid.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ApplicationDbContext applicationDbContext;

        public EditModel(ILogger<IndexModel> logger, ApplicationDbContext _applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = _applicationDbContext;
        }

        [BindProperty]
        public List<string> StudentList { get; set; }

        [BindProperty]
        public Student Students { get; set; }
        [BindProperty]
        public List<string> DropdownSelector { get; set; }
        public void OnGet(int Id)
        {
            //Students = new Student();
            Students = applicationDbContext.Student.FirstOrDefault(item => item.Id == Id);
            DropdownSelector = Students != null && Students.IsStudied != null ? Students.IsStudied.Split(",").ToList() : new List<string>();

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Students.IsStudied = string.Join(",", DropdownSelector);
            applicationDbContext.Attach(Students).State = EntityState.Modified;

            try
            {
                 applicationDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Students.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");

        }
        private bool StudentExists(int id)
        {
            return (applicationDbContext.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
