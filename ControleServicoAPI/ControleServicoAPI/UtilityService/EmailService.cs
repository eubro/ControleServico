using ControleServicoAPI.Models;
using MailKit.Net.Smtp;
using MimeKit;


namespace ControleServicoAPI.UtilityService
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration configuration) 
        {
            _config = configuration;
        }

        public void SendEmail(EmailModel model)
        {
            var emailMessage = new MimeMessage();
            var from = _config["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("eliasjunior1405@gmail.com", from));
            emailMessage.To.Add(new MailboxAddress(model.To, model.To));
            emailMessage.Subject = model.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(model.Content)
            };

            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config["EmailSettings:SmtpServer"], int.Parse(_config["EmailSettings:SmtpPort"]), true);
                    client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                    client.Send(emailMessage);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            
        }
    }
}
