using HotelBooking.Application.DTOs.UserDTOs;
using HotelBooking.Application.Results;
using HotelBooking.Application.Services.Interfaces;
using HotelBooking.Infrastructure.Identity.Entities;
using HotelBooking.Infrastructure.Identity.Secutiry;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        public AuthenticationService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }


        public async Task<Result<TokenResponseDTO>> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.Phone
            };
            var identityResult = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!identityResult.Succeeded)
            {
                return identityResult.Errors.Select(e => Error.Validation(e.Code, e.Description)).ToList();
            }
            var roleResult = await _userManager.AddToRoleAsync(user, Role.Guest.ToString());
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return Error.Failure("RoleAssignmentFailed", "User Created But Role Assignment Failed");
            }
            var accessToken = await _jwtService.GenerateTokenAsync(user);
            return new TokenResponseDTO { AccessToken = accessToken };
        }

        public async Task<Result<TokenResponseDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
            {
                return Error.InvalidCredentials("User.InvalidCrendentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isPasswordValid)
            {
                return Error.InvalidCredentials("User.InvalidCrendentials");
            }
            var accessToken = await _jwtService.GenerateTokenAsync(user);
            return new TokenResponseDTO
            {
                AccessToken = accessToken
            };
        }

    }
}
