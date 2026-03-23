using HotelBooking.Application.DTOs.UserDTOs;
using HotelBooking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiBaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<TokenResponseDTO>> Register(RegisterDTO registerDTO)
        {
            var result = await _authenticationService.RegisterAsync(registerDTO);

            return HandleResult(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(LoginDTO loginDTO)
        {
            var result = await _authenticationService.LoginAsync(loginDTO);
            return HandleResult(result);
        }

        [HttpPost("Refresh")]
        public async Task<ActionResult<TokenResponseDTO>> Refresh(RefreshRequestDTO requestDTO)
        {
            var result = await _authenticationService.RefreshTokenAsync(requestDTO);
            return HandleResult(result);
        }
    }
}
