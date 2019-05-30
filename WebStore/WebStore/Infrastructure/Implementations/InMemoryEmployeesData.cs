using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeViewModel> employees;

        public InMemoryEmployeesData()
        {
            employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    ID = 1,
                    FirstName = "Ivan",
                    SurName = "Ivanov",
                    Patronymic = "Ivanovich",
                    Position = "Manager",
                    Birthday = new DateTime(17/06/1996),
                },

                new EmployeeViewModel
                {
                    ID = 2,
                    FirstName = "Vladimir",
                    SurName = "Vladimirov",
                    Patronymic = "Vladimirovich",
                    Position = "Seller",
                    Birthday = new DateTime(20/08/1994)
                },

                new EmployeeViewModel
                {
                    ID = 3,
                    FirstName = "Alexey",
                    SurName = "Alexeev",
                    Patronymic = "Alexeevich",
                    Position = "Seller",
                    Birthday = new DateTime(25/03/1998)
                }
            };
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return employees;
        }

        /// <summary>
        /// Get employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeViewModel GetByID(int id)
        {
            return employees.FirstOrDefault(e => e.ID.Equals(id));
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        public void Add(EmployeeViewModel employee)
        {
            employee.ID = employees.Count + 1;
            employees.Add(employee);
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            employees.RemoveAll(e => e.ID.Equals(id));
        }
    }
}
