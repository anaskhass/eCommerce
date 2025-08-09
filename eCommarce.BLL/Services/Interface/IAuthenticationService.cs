using System;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;

namespace eCommarce.BLL.Services.Interface
{
	public interface IAuthenticationService
	{

		Task<UserResponse> LoginAsync(LoginRequest loginRequest);

        Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
		Task<string> ConfirEmail(string Token, string userid);
		Task<bool> ForgotPassword(ForgotPasswordRequest request);
		Task<bool> ResetPassword(ResetPasswordRequest request);
    }
}

