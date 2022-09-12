using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace asp.netcoreTelerikGrid.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public bool? IsNewStudent { get; set; }

        public bool? IsStudentUnderClass10 { get; set; }

        public string? IsStudied { get; set; }

        public List<SelectListItem> GetSelectList()
        {
            List<SelectListItem> selectListItem = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Java", Value = "java" },
                new SelectListItem() { Text = "Python", Value = "Python" },
                new SelectListItem() { Text = "C#", Value = "C#" },
                new SelectListItem() { Text = "JavaScript", Value = "JavaScript" },
                new SelectListItem() { Text = "Django", Value = "Django" },
                new SelectListItem() { Text = "Asp.net core", Value = "Asp.net core" },
                new SelectListItem() { Text = "React.js", Value = "React.js" }
            };
            return selectListItem;
        }
    }

    //public enum classes
    //{
    //    one = 1,
    //    two = 2,
    //    three = 3,
    //    four = 4,
    //    five = 5,
    //    six = 6,
    //    seven = 7,
    //    eight = 8,
    //    nine = 9,
    //    ten = 10
    //}

}
