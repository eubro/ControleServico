namespace ControleServicoAPI.Models
{
    public class CadServico
    {
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public double valor { get; set; }
        public string numero { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;

        
    }
}
