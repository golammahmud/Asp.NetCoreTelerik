using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Model;

namespace WebApplication3.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.WebApplication3Context _context;

        public IndexModel(WebApplication3.Data.WebApplication3Context context)
        {
            _context = context;
        }
        public static IList<Employees> Employee;


        //public IList<Employees> Employee { get; set; } = default!;
        public void OnGet()
        {
            if (_context.Employee != null)
            {
                Employee =_context.Employee.ToList();
           }
        //if (Employee == null)
        //{
        //    Employee = new List<Employees>();

                //    Enumerable.Range(1, 50).ToList().ForEach(i => Employee.Add(new Employees
                //    {
                //        Id = i,
                //        Date = DateTime.Now.AddDays(i % 7),
                //        Name = "ShipName " + i,
                //        Adderss = "ShipCity " + i,
                //        Email = "Ejjj@gmail.com " + i,
                //    }));

                //}
        }

        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            return new JsonResult(_context.Employee.ToDataSourceResult(request));
        }

        public JsonResult OnPostCreate([DataSourceRequest] DataSourceRequest request, Employees employee)
        {
            //if (!ModelState.IsValid || _context.Employee == null || employee == null)
            //{
            //    return NotFound();
            //}

            _context.Employee.Add(employee);
             _context.SaveChanges();

            return new JsonResult(new[] { employee }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, Employees employee)
        {

            _context.Attach(employee).State = EntityState.Modified;

            _context.SaveChanges();


            //_context.Employee.Where(x => x.Id == employee.Id).Select(x => employee);
            //_context.SaveChanges();

            return new JsonResult(new[] { employee }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, Employees employee)
        {
            //Employee.Remove(Employee.FirstOrDefault(x => x.Id == employee.Id));

            //_context.Employee.Remove(Employee);
            // _context.SaveChangesAsync();

            var employees =  _context.Employee.Find(employee.Id);
            _context.Employee.Remove(employees);
            _context.SaveChanges();
            

            return new JsonResult(new[] { employee }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult OnPostSave(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }



        //public async Task OnGetAsync()
        //{
        //    if (_context.Employee != null)
        //    {
        //        Employee = await _context.Employee.ToListAsync();
        //    }
        //}
    }
}
