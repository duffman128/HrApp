using HrApp.Interfaces.BusinessRules;
using HrApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Business.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRules employeeRules;

        public EmployeeController(IEmployeeRules _employeeRules)
        {
            employeeRules = _employeeRules;
        }

        [HttpGet("getemployees")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await employeeRules.GetEmployeesAsync();
            return Ok(employees);
        }


        [HttpGet("getemployee/{employeeid}")]
        public async Task<IActionResult> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await employeeRules.GetEmployeeAsync(employeeId);
            return Ok(employee);
        }

        [HttpPost("postemployee")]
        public async Task<IActionResult> PostEmployeeAsync([FromBody] Employee employee)
        {
            await employeeRules.AddEmployeeAsync(employee);
            return Ok();
        }

        [HttpPut("putemployee")]
        public async Task<IActionResult> PutEmployeeAsync([FromBody] Employee employee)
        {
            await employeeRules.UpdateEmployeeAsync(employee);
            return Ok();
        }
    }
}
