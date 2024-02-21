using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Errors.Model;
using SendGrid.Helpers.Mail;
using System.Net;

namespace GerenciadorDeViagemApi.Infrastructure.Services
{
    public class EmailServices : IEmailService
    {
        private readonly string Key;
        private readonly string FromEmail;
        public EmailServices(IConfiguration configuration)
        {
            Key = configuration["SendGrid:Key"]!;
            FromEmail = configuration["SendGrid:FromEmail"]!;
        }
        public async Task<bool> SendEmailAsync(EmailDTO email)
        {
            try
            {
                var client = new SendGridClient(Key);
                var sendMessage = new SendGridMessage();

                sendMessage.SetFrom(FromEmail, "Travel - ADM ");
                sendMessage.AddTo(email.Email, email.NomeCompleto);
                sendMessage.SetSubject(email.EmailSubject);

                sendMessage.AddContent(
                                        MimeType.Html,
                                        email.EmailTemplate
                                      );
               
                var response = await client.SendEmailAsync(sendMessage);

                return response.StatusCode is HttpStatusCode.Accepted;
            }
            catch (SendGridInternalException)
            { return false; }
            
            catch (Exception)
            { return false; }
        }
    }
}
