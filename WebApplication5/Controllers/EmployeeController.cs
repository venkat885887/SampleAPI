using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;

namespace SampleApi.Controllers
{
    [Route("/api/[controller]")]  //define the URL formate (routeing/route)
    [ApiController]  //first need to decorate this attribute
    public class EmployeeController : ControllerBase
    {
        // GET: https://localhost:7214/api/Employee
        [HttpGet] //decorate the HttpGet Attribute
        public IActionResult GetEmployees()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            var employeeData = employeeDAL.GetAllEmployess();

          //  Ok(); //just it will return the 200 status code
           return Ok(employeeData); // 200 status along with emploess data
        }



        // GET: https://localhost:7214/api/Employee/10
        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee([FromQuery] int id)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            var employeeData = employeeDAL.GetEmployesById(id);

            return Ok(employeeData);
        }

        // POST: https://localhost:7214/api/Employee
        [HttpPost]
       
        public IActionResult PostEmployee([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Simulate adding a new employee (in a real application, you'd typically save to a database)
            employee.Id = employees.Count + 1;
            employees.Add(employee);

            // Return the created employee with status code 201 Created
            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // PUT: https://localhost:7214/api/Employee/10
        [HttpPut("{{id}}")]
       
        public IActionResult PutEmployee([FromQuery] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update the existing employee (in a real application, you'd typically update in the database)
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;

            return Ok();
        }

        // DELETE: https://localhost:7214/api/Employee/10
        [HttpDelete("{{id}}")]
        public IActionResult DeleteEmployee([FromQuery] int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);

            return Ok();
        }

        // DELETE: https://localhost:7214/api/Employee/10
        [HttpGet()]
        [Route("GetOnlyEmployeeAddress")]
        public IActionResult GetOnlyEmployeeAddress([FromQuery] int id)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting employee.");
        }


        private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Department = "IT" },
        new Employee { Id = 2, Name = "Jane Smith", Department = "HR" }
        // Add more initial employees as needed
    };

    }
}
