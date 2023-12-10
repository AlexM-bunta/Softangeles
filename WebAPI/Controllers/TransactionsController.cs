using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsService _service;

    public TransactionsController(ITransactionsService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddTransaction([FromBody] TransactionContract transactionContract)
    {
        try
        {
            if (transactionContract == null)
                throw new ArgumentException();

            var requestStatus = await _service.ProcessTransaction(transactionContract);

            if (requestStatus == TransactionProcessResponseCode.SourceAccountNotFound)
                return BadRequest("Source account invalid.");

            if (requestStatus == TransactionProcessResponseCode.DestinationAccountNotFound)
                return BadRequest("Destination account invalid.");

            if (requestStatus == TransactionProcessResponseCode.NotEnoughBalance)
                return BadRequest("Not enough balance invalid.");

            if (requestStatus == TransactionProcessResponseCode.Fail)
                throw new Exception();

            return Ok(requestStatus);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}