using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register-moderator")]
        public async Task<ActionResult<ResponseDto<string>>> Register(ModeratorRegistrationRequestDto request)
        {
            try
            {
                StaffResponseDto response = await _adminService.RegisterModeratorAsync(request);
                return Ok(new ResponseDto<string>
                {
                    Status = 200,
                    Message = "Success",
                    Data = response.ToString()
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
