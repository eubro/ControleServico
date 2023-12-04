namespace ControleServicoAPI.Models
{
    public class CadServico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Valor { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Concluido { get; set; }

        
    }
}
