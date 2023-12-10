using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoansController : ControllerBase
{
    private readonly ILoansService _service;

    public LoansController(ILoansService service)
    {
        _service = service;
    }
    
    [HttpGet("{sessionId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCardsByAccountId(Guid sessionId)
    {
        try
        {
            if (sessionId == null)
                throw new ArgumentException();

            var requestStatus = await _service.GetUserLoans(sessionId);

            if (requestStatus.UserLoansResponseCode == UserLoansResponseCode.UserNotFound)
                return BadRequest("User not found.");
            
            if (requestStatus.UserLoansResponseCode == UserLoansResponseCode.NoObjectsFound)
                return BadRequest("No loans found for this user.");

            if (requestStatus.UserLoansResponseCode == UserLoansResponseCode.Fail)
                throw new Exception("Request failed.");

            return Ok(requestStatus.Loans);
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
    public async Task<IActionResult> AddLoan([FromBody] LoanAddWithSessionContract loanContract)
    {
        try
        {
            if (loanContract == null)
                throw new ArgumentException();

            var requestStatus = await _service.AddLoan(loanContract);

            if (requestStatus == UserLoansResponseCode.UserNotFound)
                return BadRequest("User not found.");

            if (requestStatus == UserLoansResponseCode.Fail)
                throw new Exception("Request failed.");

            return Ok(requestStatus);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}