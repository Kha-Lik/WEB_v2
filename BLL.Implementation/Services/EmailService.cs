using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using BLL.Models;
using DAL.Abstract;
using DAL.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace BLL.Implementation.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public EmailService(IUnitOfWork unit, IMapper mapper, IConfiguration configuration)
        {
            _unit = unit;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kpi.acts.it81@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                var userName = _configuration.GetSection("EmailServerCredentials")["Email"];
                var password = _configuration.GetSection("EmailServerCredentials")["Password"];
                await client.AuthenticateAsync(userName, password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);

            return await _unit.UserManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}