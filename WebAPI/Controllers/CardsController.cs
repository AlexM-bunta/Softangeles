using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CardsController : ControllerBase
{
    private readonly ICardsService _service;

    public CardsController(ICardsService service)
    {
        _service = service;
    }

    [HttpGet("{accountId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCardsByAccountId(int accountId)
    {
        try
        {
            if (accountId == 0)
                throw new ArgumentException();

            var requestStatus = await _service.GetCardsByAccountId(accountId);

            if (requestStatus.AccountResponseCode == AccountResponseCode.NoObjectsFound)
                return BadRequest("No cards found for this account.");

            return Ok(requestStatus.CardsList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}