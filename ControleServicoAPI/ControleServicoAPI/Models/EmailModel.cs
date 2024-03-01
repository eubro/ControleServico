namespace ControleServicoAPI.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailModel(string to, string sunject, string content) 
        {
            To = to;
            Subject = sunject;
            Content = content;
        }
    }
}
