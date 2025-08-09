using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using eCommarce.BLL.Services.Interface;
using IAuthenticationService = eCommarce.BLL.Services.Interface.IAuthenticationService;

namespace eCommarce.PL.Controllers;

[ApiController]
[Area("Identity")]
[Route("api/[area]/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserResponse>> Register( RegisterRequest registerRequest)
    {
        var result = await _authenticationService.RegisterAsync(registerRequest);

        

        return Ok(result);
    }

   

    [HttpPost("Login")]
    public async Task<ActionResult<UserResponse>> Login(LoginRequest  loginRequest)
    {
        var result = await _authenticationService.LoginAsync(loginRequest);



        return Ok(result);
    }


    [HttpGet("ConfirmEmail")]
    public async Task<ActionResult<string>> ConfirmEmail([FromQuery]string Token, [FromQuery] string userid)
    {
        var result = await _authenticationService.ConfirEmail(Token, userid);



        return Ok(result);
    }



    [HttpPost("forgit-password")]
    public async Task<ActionResult<string>> Forgotpassword([FromBody] ForgotPasswordRequest request)
    {
        var result = await _authenticationService.ForgotPassword(request);



        return Ok(result);
    }



    [HttpPatch("reset-password")]
    public async Task<ActionResult<string>> Restpasswoed([FromBody]  ResetPasswordRequest request)
    {
        var result = await _authenticationService.ResetPassword(request);



        return Ok(result);
    }

}





