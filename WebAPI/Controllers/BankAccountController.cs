using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BankAccountController : ControllerBase
{
    private readonly IBankAccountService _service;
    
    public BankAccountController(IBankAccountService service)
    {
        _service = service;
    }
    
    [HttpGet("{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserDetails(Guid? sessionId)
    {
        try
        {
            if (sessionId == null)
                throw new ArgumentException();

            var requestStatus = await _service.GetBankAccountDetailsBySessionId(sessionId.GetValueOrDefault());

            if (requestStatus.BankAccountResponseCode == BankAccountResponseCode.NoAccounts)
                return BadRequest("No accounts found for this user.");

            return Ok(requestStatus.BankAccountDetailsList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}