using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class PartnersController : ControllerBase
{
    private readonly IPartnersService _service;

    public PartnersController(IPartnersService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPartners()
    {
        try
        {
            var requestStatus = await _service.GetPartners();

            if (requestStatus.BaseResponseCode == BaseResponseCode.NoObjectsFound)
                return BadRequest("No partners found.");

            return Ok(requestStatus.Partners);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetEcoPartners()
    {
        try
        {
            var requestStatus = await _service.GetEcoPartners();

            if (requestStatus.BaseResponseCode == BaseResponseCode.NoObjectsFound)
                return BadRequest("No partners found.");

            return Ok(requestStatus.Partners);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}