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
            //TempData["Message"] = "Hi";
            ViewBag.ButtonName = "Create";
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Index(Employee employee)
        {
            //var sample = TempData["Message"].ToString();
            if(employee.ID>0)
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
            }
          
            return RedirectToAction("EmployeeList");
        }

        public  async Task<IActionResult> EmployeeList()
        {
            return View(await _context.Employees.ToListAsync());
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee==null)
            {
                return NotFound();
            }
            ViewBag.ButtonName = "Update";
            return View("Index",employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
             _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("EmployeeList");
        }
    }
}
