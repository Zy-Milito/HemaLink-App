using Application.Models.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto<string>>> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                string token = await _authService.LoginAsync(request);
                return Ok(new ResponseDto<string>
                {
                    Status = 200,
                    Message = "Success",
                    Data = token
                });
            }
            catch (UnauthorizedAccessException exception)
            {
                return Unauthorized(new ResponseDto<string>
                {
                    Status = 401,
                    Message = exception.Message,
                    Data = null
                });
            }
        }

        [HttpPost("requester-requester")]
        public async Task<ActionResult<ResponseDto<string>>> Register(RequesterRegistrationRequestDto request)
        {
            try
            {
                string token = await _authService.RegisterRequesterAsync(request);
                return Ok(new ResponseDto<string>
                {
                    Status = 200,
                    Message = "Success",
                    Data = token
                });
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(new ResponseDto<string>
                {
                    Status = 400,
                    Message = exception.Message,
                    Data = null
                });
            }
        }
    }
}
