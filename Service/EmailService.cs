using Entity.ConfigurationModels;
using Entity.Exceptions;
using Entity.Model;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Service.Contracts;
using Shared.DataTransferObjects.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmailService : IEmailService
    {
       
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            
            _settings = emailSettings.Value;
        }

        public async Task AccountEmailAsync(UserForRegistrationDto UserForRegistrationDto, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.AppName, _settings.SmptUserName));
            message.To.Add(new MailboxAddress(UserForRegistrationDto.FirstName, UserForRegistrationDto.Email));
            message.Subject = "Account Created Successfully";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = $@" <h1> Welcome, {UserForRegistrationDto.FirstName}</h1>
                            <p>Your account has been successfully created.</p>
                            <p>Click on the link to confirm email <a href=""{link}"">{link}</a>.</p> 
                            <p>Thank you for registering with us.</p>
                            <br/>
                            <p> - The Team </p>"

            };

            

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_settings.SmtpHost, _settings.SmptPort, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.SmptUserName, _settings.SmptPassword);
                await smtp.SendAsync(message);
            }
            catch
            {
                
                throw new EmailNotSentException();
            }
            finally  
            {
                await smtp.DisconnectAsync(true);
            }
            
        }
    }
}
