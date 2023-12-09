using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses.Enums;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;
    
    public UsersController(IUsersService service)
    {
        _service = service;
    }
    
    [HttpGet("{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserDetails(Guid? sessionId)
    {
        try
        {
            if (sessionId == null)
                throw new ArgumentException();

            var requestStatus = await _service.GetUserDetails(sessionId.GetValueOrDefault());

            if (requestStatus.UserResponseCode == UserResponseCode.UserNotFound)
                return BadRequest("User not found.");

            return Ok(requestStatus.User);
        }
        catch (ArgumentException ae)
        {
            return BadRequest("Invalid parameters. Check body.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Logout([FromBody] UserSessionContract userSessionContract)
    {
        try
        {
            if (userSessionContract == null)
                throw new ArgumentException();

             var requestStatus = await _service.Logout(userSessionContract.Session);

            if (!requestStatus)
                return StatusCode(StatusCodes.Status406NotAcceptable, "Something went wrong.");

            return Ok();
        }
        catch (ArgumentException ae)
        {
            return BadRequest("Invalid parameters. Check body.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] UserBaseContract userContract)
    {
        try
        {
            if (userContract == null ||
                userContract.Username == null ||
                userContract.Password == null)
                throw new ArgumentException();
            
            var loginResponse = await _service.Login(userContract);

            switch (loginResponse.UserResponseCode)
            {                
                case UserResponseCode.PasswordNotCorrect:
                    return BadRequest("Password is not correct.");
                
                case UserResponseCode.UserNotFound:
                    return BadRequest("User not found.");
            };

            return Ok(loginResponse.SessionId.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserRegisterContract userContract)
    {
        try
        {
            if (userContract == null)
                throw new ArgumentException();

            var requestStatus = await _service.Register(userContract);

            if (!requestStatus)
                return StatusCode(StatusCodes.Status406NotAcceptable, "Something went wrong.");

            return Ok();
        }
        catch (ArgumentException ae)
        {
            return BadRequest("Invalid parameters. Check body.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

