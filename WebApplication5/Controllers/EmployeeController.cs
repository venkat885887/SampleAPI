using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Models;

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
       
        public IActionResult PostEmploye([FromBody] AddEmploeeDto employee)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            var empId = employeeDAL.AddEmployee(employee);
            return Ok(empId);
        }

        // PUT: https://localhost:7214/api/Employee/10
        [HttpPut("{{id}}")]
       
        public IActionResult PutEmployee([FromQuery] int id, [FromBody] EmployeeDto employee)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employee.EmpId = id;
            var updatedEmployee = employeeDAL.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }

        // DELETE: https://localhost:7214/api/Employee/10
        [HttpDelete("{{id}}")]
        public IActionResult DeleteEmployee([FromQuery] int id)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            var deletedStatus = employeeDAL.DeleteEmployee(id);
            return Ok(deletedStatus);
        }

        // DELETE: https://localhost:7214/api/Employee/10
        [HttpGet()]
        [Route("GetOnlyEmployeeAddress")]
        public IActionResult GetOnlyEmployeeAddress()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            var empAddresses = employeeDAL.GetAllEmployessAddress();
            return Ok(empAddresses);
        }
    }
}
