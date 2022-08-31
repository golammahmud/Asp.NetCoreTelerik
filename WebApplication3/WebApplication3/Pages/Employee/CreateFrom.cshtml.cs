using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Model;

namespace WebApplication3.Pages.Employee
{
    public class CreateFromModel : PageModel
    {
        private readonly WebApplication3Context _context;

        public CreateFromModel(WebApplication3Context context)
        {
            _context = context;
        }



        [BindProperty]
        public BaseModel employeeBase { get; set; }
       
        

        public void OnGet()
        {
            if (employeeBase == null)
            {
                employeeBase = new BaseModel();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Employees employeeData = new Employees();
            employeeData.Name = employeeBase.model1.Name;
          


            _context.Employee.Add(employeeData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //public IActionResult OnPostSubmit(Employees employee)
        //{

        //    _context.Employee.Add(employee);
        //    _context.SaveChanges();
        //    return RedirectToPage("./Index");

        //}
        //public IActionResult OnPostSubmit(Employees employee)
        //{

        //    _context.Employee.Add(employee);
        //    _context.SaveChanges();
        //    return RedirectToPage("./Index");

        //}
    }
}
