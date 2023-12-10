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
    public async Task<IActionResult> GetAccounts(Guid? sessionId)
    {
        try
        {
            if (sessionId == null)
                throw new ArgumentException();

            var requestStatus = await _service.GetBankAccountDetailsBySessionId(sessionId.GetValueOrDefault());

            if (requestStatus.AccountResponseCode == BaseResponseCode.NoObjectsFound)
                return BadRequest("No accounts found for this user.");

            return Ok(requestStatus.BankAccountDetailsList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAccount([FromBody] AccountAddContract accountContract)
    {
        try
        {
            if (accountContract == null)
                throw new ArgumentException();

            var responseCode = await _service.AddAccount(accountContract);

            if (responseCode == AccountAddResponseCode.TypeNotFound)
                return BadRequest("Account type not valid.");

            if (responseCode == AccountAddResponseCode.Fail)
                throw new Exception("Request failed.");

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}