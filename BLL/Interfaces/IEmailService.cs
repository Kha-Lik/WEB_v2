﻿using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IEmailService
    {
        
        Task SendEmailAsync(string email, string subject, string message);

        Task<string> GenerateEmailConfirmationTokenAsync(UserRegistrationModel model);
    }
}