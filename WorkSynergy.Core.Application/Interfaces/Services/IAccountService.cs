using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.DTOs.Account;
using WorkSynergy.Core.Application.ViewModels.Account;
using WorkSynergy.Core.Application.Wrappers;

namespace WorkSynergy.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Response<UserDTO>> GetByIdAsyncDTO(string id);
        Task<ManyUserResponse> GetAllByRoleDTO(GetAllByRoleRequest request);
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
