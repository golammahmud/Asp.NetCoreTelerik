using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Data;
using WebApplication3.Model;

namespace WebApplication3.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication3Context _context;

        public CreateModel(WebApplication3Context context)
        {
            _context = context;
        }

       

        [BindProperty]
        public Employees employee { get; set; }

      
        public void OnGet()
        {
            if (employee == null)
            {
                employee = new Employees();
            }
        }

        //public IActionResult OnPostSubmit(Employees employee)
        //{

        //        _context.Employee.Add(employee);
        //        _context.SaveChanges();
        //        return RedirectToPage("./Index");

        //}
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Employee == null || employee == null)
            {
                return Page();
            }

            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    }
