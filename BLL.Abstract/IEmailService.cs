using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);
    }
}