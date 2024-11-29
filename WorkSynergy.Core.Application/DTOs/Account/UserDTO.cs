﻿using WorkSynergy.Core.Application.DTOs.Entities.Ability;

namespace WorkSynergy.Core.Application.Dtos.Account
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserImagePath { get; set; }
        public List<string> Roles { get; set; }
        public List<AbilityResponse> Abilities { get; set; }

        public bool IsActive { get; set; }
    }
}
