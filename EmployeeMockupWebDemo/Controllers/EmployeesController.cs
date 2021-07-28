using EmployeeMockupWebDemo.Data.BLL;
using EmployeeMockupWebDemo.Data.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = EmployeeBLL.GetAll()});
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Random r = new Random();
                    employee.Id = EmployeeBLL.GetAll().Count+1*2+r.Next(10, 20);
                    EmployeeBLL.AddEmployee(employee);
                    return RedirectToAction(nameof(Index), "Home");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee emp = new Employee();
            if(id != 0)
            {
                emp = EmployeeBLL.GetEmployee(id);
            }
            return View(emp);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeBLL.UpdateEmployee(employee);
                    return RedirectToAction(nameof(Index), "Home");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeesController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeBLL.DeleteEmployee(id);
                return Json(new { success = true});
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult RowsToDelete(String Employees)
        {
            try
            {
                var employeesIds = JArray.Parse(Employees);
                if (employeesIds.Count() > 0)
                {
                    foreach (int e in employeesIds)
                    {
                        EmployeeBLL.DeleteEmployee(e);
                    }
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }
}
