﻿namespace KartRacer.API.Models.User
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
