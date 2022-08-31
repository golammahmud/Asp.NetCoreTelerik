using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kendo.Mvc.UI;
using WebApplication3.Model;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WebApplication3.Data.WebApplication3Context _context;

        [BindProperty]
        public Employees employee { get; set; } = default!;
        public Employees Employee { get; set; }
        public JsonResult Getdata;
        public static List<Employees> Order;

        public IndexModel(ILogger<IndexModel> logger, WebApplication3.Data.WebApplication3Context context)
        {
            _logger = logger;
             _context = context;
        }

        public void OnGet()
        {
            if (employee == null)
            {
                employee = new Employees();
            }
            //if (orders == null)
            //{
            //    orders = new List<Employees>();

            //    Enumerable.Range(1, 50).ToList().ForEach(i => orders.Add(new Employees
            //    {
            //        Name = "ship name " + i
            //    }));

            //}
        }
        public JsonResult OnGetRead(string filterValue)
        {
            if (filterValue !=null)
            {
                //orders is the DBContext
                var filteredData = _context.Employee.Where(p => p.Name.Contains(filterValue)).ToList();
                return new JsonResult(filteredData);
            }
            return new JsonResult(Order);
        }

       
        public IActionResult OnPost()
        {
            var model = Request.Form;
            



            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Employee.Add(employee);
            _context.SaveChanges();

            return RedirectToPage("./Index");

        }
        //public JsonResult OnPostGetCustomers(Employees a)
        //{
        //    var retval = new[]
        //    {
        //        new {name = "Bob Builders",code = "BB" },
        //        new {name = "Other", code = "Other" }
        //    }.ToList();

        //    return new JsonResult(retval);

        //}


    }
}