﻿namespace ControleServicoAPI.Models.Dto
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Emailtoken { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
