using HrApp.Interfaces.BusinessRules;
using HrApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Business.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRules addressRules;

        public AddressController(IAddressRules _addressRules)
        {
            addressRules = _addressRules;
        }

        [HttpGet("getemployeeaddresses/{employeeId}")]
        public async Task<IActionResult> GetEmployeeAddressesAsync(Guid employeeId)
        {
            var addresses = await addressRules.GetAddresseseAsync(employeeId);

            return Ok(addresses);
        }

        [HttpPost("postemployeeaddress")]
        public async Task<IActionResult> PostEmployeeAddressAsync([FromBody] Address address)
        {
            await addressRules.AddAddressAsync(address);
            return Ok();
        }

        [HttpPut("putemployeeaddress")]
        public async Task<IActionResult> PutEmployeeAddressAsync([FromBody] Address address)
        {
            await addressRules.UpdateAddressAsync(address);
            return Ok();
        }
    }
}
