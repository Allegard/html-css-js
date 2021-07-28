using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Data.DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [Display(Name = "Last Name")]
        public String Lastname { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format!")]
        [Display(Name = "Email")]
        public String Email { get; set; }
    }
}
