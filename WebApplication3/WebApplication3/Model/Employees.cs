using Kendo.Mvc.UI;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Employees:EmptestModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adderss { get; set; }
        public DateTime Date { get; set; }



    }
}
