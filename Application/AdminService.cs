using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Enums;

namespace Application
{
    public class AdminService : IAdminService
    {
        private readonly IAccountRepository<Account> _accountRepository;
        public AdminService(IAccountRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<StaffResponseDto> RegisterModeratorAsync(ModeratorRegistrationRequestDto request)
        {
            if (await _accountRepository.GetAsync(request.Email) != null)
            {
                throw new InvalidOperationException("This email is already used.");
            }

            Staff user = new Staff
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = StaffRole.Moderator
            };
            await _accountRepository.AddAsync(user);

            return new StaffResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<StaffResponseDto> PromoteModeratorAsync(ModeratorPromotionDto request)
        {
            Account? user = await _accountRepository.GetAsync(request.Email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (user is not Staff staffUser)
            {
                throw new InvalidOperationException("User is not a moderator.");
            }

            if (staffUser.Role == StaffRole.Admin)
            {
                throw new InvalidOperationException("User is already admin.");
            }

            staffUser.Role = StaffRole.Admin;

            await _accountRepository.UpdateAsync(staffUser);

            return new StaffResponseDto
            {
                Id = staffUser.Id,
                Name = staffUser.Name,
                Email = staffUser.Email,
                Role = staffUser.Role.ToString()
            };

        }
    }
}