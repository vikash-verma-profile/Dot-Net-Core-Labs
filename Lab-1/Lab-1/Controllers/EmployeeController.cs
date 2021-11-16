using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Index(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return View("EmployeeList");
        }

        public  async Task<IActionResult> EmployeeList()
        {
            return View(await _context.Employees.ToListAsync());
        }
    }
}
