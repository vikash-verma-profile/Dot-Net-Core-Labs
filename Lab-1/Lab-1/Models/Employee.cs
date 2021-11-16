using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    public class Employee
    {   
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter employee id")]
        public string EmployeeID { get; set; }
        [Required(ErrorMessage = "Please enter employee name")]
        public string EmployeeName { get; set; }
    }
}
