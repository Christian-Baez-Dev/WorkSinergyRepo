using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.ViewModels.Account;

namespace WorkSynergy.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<UserDTO> GetByIdAsyncDTO(string id);
        Task<List<UserDTO>> GetAllByRoleDTO(string Role);

        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<UserRegisterResponse> RegisterUserAsync(UserRegisterRequest request, string origin);
        Task<UserEditResponse> EditUserAsync(UserEditRequest request, string origin);
        Task SignOutAsync();
        Task<int> GetActiveUsers(string? role = null);
        Task<int> GetInactiveUsers(string? role = null);
        Task DeactivateUser(string id);
        Task ActivateUser(string id);
        Task<UserDeleteResponse> DeleteAsync(string id);
    }
}
