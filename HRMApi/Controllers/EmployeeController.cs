using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HRMApi.Models;

namespace HRMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = "1", Name = "John Doe", Email = "john.doe@example.com", Department = "IT" },
            new Employee { Id = "2", Name = "Jane Smith", Email = "jane.smith@example.com", Department = "HR" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employees;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employees.Remove(employee);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Employee>> Search(string name)
        {
            var foundEmployees = _employees.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
            if (foundEmployees.Count == 0)
            {
                return NotFound();
            }
            return foundEmployees;
        }
    }
}
