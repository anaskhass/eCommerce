using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eCommarce.BLL.Services.Interface;
using eCommarce.DAL.DTO.Requests;
using eCommarce.DAL.DTO.Responses;
using eCommarce.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace eCommarce.BLL.Services.Class
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configurtion;
        private readonly IEmailSender emailSender;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IConfiguration configurtion,
            IEmailSender emailSender

            )
        {
            this.userManager = userManager;
            this.configurtion = configurtion;
            this.emailSender = emailSender;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {

            var user = await userManager.FindByEmailAsync(loginRequest.Email);
            if(user is null)
            {
                throw new Exception("Invalid EmailOrPassword");     
            }


            if (!await userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("Plz confirm your email");

            }

           var IsPasswordValid= await userManager.CheckPasswordAsync(user,loginRequest.Password);

            if (!IsPasswordValid)
            {
                throw new Exception("INVALID  Email Or Password");
            }



            return new UserResponse
            {
                Token = await CreateTokenAsyn(user)
            };

        }
        public async Task<string> ConfirEmail(string Token,string userid)
        {
            var user = await userManager.FindByIdAsync(userid);
            if(user is null)
            {
                throw new Exception("user Not Found");

            }

            var result = await userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
            {

                return "Email Confirmrd succsfully";
            }

            return "Email Confirmrd faild";
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                UserName = registerRequest.UserName,
                Email=registerRequest.Email,
                PhoneNumber=registerRequest.PhoneNumber
            };
          var Result=  await userManager.CreateAsync(user,registerRequest.Password);
            if (Result.Succeeded)
            {

                var Token=await userManager.GenerateEmailConfirmationTokenAsync(user);

                var ecapetoken = Uri.EscapeDataString(Token);

                var url = $"https://localhost:7244/api/Identity/Account/ConfirmEmail?Token={ecapetoken}&userid={user.Id}";

                await emailSender.SendEmailAsync(user.Email,"Welcome",$"<h1> Hello {user.FullName}</h1>"+

                    $"<a href= '{url}'> plz click here to Comfirem  </a>"

                    );




                return new UserResponse
                {
                    Token = registerRequest.Email,


                };

            }


            else
            {
                var errors = string.Join("; ", Result.Errors.Select(e => e.Description));
                throw new Exception(errors);
            }


        }



        private async Task<string> CreateTokenAsyn(ApplicationUser user)
        {
            var Clames = new List<Claim>
            {
                new Claim("Email", user.Email ),
                new Claim("Id",user.Id),
                new Claim("Name",user.UserName)
            };

            var Roles = await userManager.GetRolesAsync(user);


            foreach (var role in Roles)
            {
                Clames.Add(new Claim("UserRole", role));
                //Clames.Add(new Claim(ClaimTypes.Role, role));

            }


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sasSVdxL73nhMct3p3WfHhTMl2YENYwR"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                claims: Clames,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

          public async Task<bool> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if(user is null)
            {
                throw new Exception("user not found");
            }
            var random = new Random();
            var code = random.Next(1000, 9999).ToString();

            user.CodeResetPassword = code;
            user.resetPawwordExpiry = DateTime.UtcNow.AddMinutes(15);
            await userManager.UpdateAsync(user);


            await emailSender.SendEmailAsync(request.Email, "reset password", $"<p> code is {code}  </p>");
            return true;

        }


        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new Exception("user not found");
            }

            if (user.CodeResetPassword != request.Code) return false;
            if (user.resetPawwordExpiry < DateTime.UtcNow) return false;

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
            {
                await emailSender.SendEmailAsync(request.Email, "Change Password", "<h1>Your paswword is changed </h1>");

            }
            return true;
        }


    }
}

