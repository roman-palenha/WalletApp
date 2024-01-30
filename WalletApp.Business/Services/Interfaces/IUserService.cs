using WalletApp.Business.Dto;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);
        Task<int> CalculatePointsAsync(int id);
        Task<User> CreateUserAsync(UserDto user);
    }
}
