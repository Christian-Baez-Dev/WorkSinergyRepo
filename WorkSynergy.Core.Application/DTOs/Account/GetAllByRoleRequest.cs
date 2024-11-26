namespace WorkSynergy.Core.Application.DTOs.Account
{
    public class GetAllByRoleRequest
    {
        public string Role { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
