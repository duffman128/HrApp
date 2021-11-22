using HrApp.Interfaces.BusinessRules;
using HrApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrApp.Business.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly IContactDetailRules contactDetailRules;

        public ContactDetailController(IContactDetailRules _contactDetailRules)
        {
            contactDetailRules = _contactDetailRules;
        }

        [HttpGet("getemployeecontactdetails/{employeeId}")]
        public async Task<IActionResult> GetEmployeeContactDetailsAsync(Guid employeeId)
        {
            var contactDetails = await contactDetailRules.GetContactDetailsAsync(employeeId);
            return Ok(contactDetails);
        }

        [HttpPost("postemployeecontactdetail")]
        public async Task<IActionResult> PostEmployeeContactDetailAsync([FromBody] ContactDetail contactDetail)
        {
            await contactDetailRules.AddContactDetailAsync(contactDetail);
            return Ok();
        }

        [HttpPut("putemployeecontactdetail")]
        public async Task<IActionResult> PutEmployeeContactDetailAsync([FromBody] ContactDetail contactDetail)
        {
            await contactDetailRules.UpdateContactDetailAsync(contactDetail);
            return Ok();
        }
    }
}
