using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData employeesData;

        public EmployeeController(IEmployeesData employeesData)
        {
            this.employeesData = employeesData;
        }

        /// <summary>
        /// List of employees
        /// </summary>
        /// <returns></returns>
        [Route("employees")]
        public IActionResult Employees()
        {
            return View(employeesData.GetAll());
        } 

        /// <summary>
        /// Employee details
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <returns></returns>
        [Route("employee/details")]
        public IActionResult Details(int id)
        {
            var employee = employeesData.GetByID(id);

            if (ReferenceEquals(employee, null))
                return NotFound();

            return View(employee);
        }

        /// <summary>
        /// Add or edit employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("employee/edit/{id?}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            EmployeeViewModel employee;
            if (id.HasValue)
            {
                employee = employeesData.GetByID(id.Value);
                if (ReferenceEquals(employee, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                employee = new EmployeeViewModel();
            }
            return View(employee);
        }

        [HttpPost]
        [Route("employee/edit/{id?}")]
        [Authorize(Roles="Administrator")]
        public IActionResult Edit(EmployeeViewModel employee)
        {
            int age = int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(employee.Birthday.ToString("yyyyMMdd")) / 10000;

            if (age < 18 && age > 75)
                ModelState.AddModelError("Birthday", "Invalid age");

            if (ModelState.IsValid)
            {
                if (employee.ID > 0)
                {
                    var dbItem = employeesData.GetByID(employee.ID);

                    if (ReferenceEquals(dbItem, null))
                        return NotFound();

                    dbItem.FirstName = employee.FirstName;
                    dbItem.SurName = employee.SurName;
                    dbItem.Patronymic = employee.Patronymic;
                    dbItem.Birthday = employee.Birthday;
                    dbItem.Position = employee.Position;
                }
                else
                {
                    employeesData.Add(employee);
                }

                return RedirectToAction(nameof(Employees));
            }

            return View(employee);
        }

        /// <summary>
        /// Remove employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("employee/delete/{id?}")]
        [Authorize(Roles="Administrator")]
        public IActionResult Delete(int id)
        {
            employeesData.Delete(id);

            return RedirectToAction(nameof(Employees));
        }

    }
}