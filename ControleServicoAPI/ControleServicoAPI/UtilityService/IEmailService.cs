using ControleServicoAPI.Models;

namespace ControleServicoAPI.UtilityService
{
    public interface IEmailService
    {
        void SendEmail(EmailModel model);
    }
}
