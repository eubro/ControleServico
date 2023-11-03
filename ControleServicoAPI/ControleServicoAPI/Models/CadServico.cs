namespace ControleServicoAPI.Models
{
    public class CadServico
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public double valor { get; set; }
        public string numero { get; set; }
        public string descricao { get; set; }

        public CadServico(){}

        public CadServico(string nome, double valor, string numero, string descricao)
        {
            this.nome = nome;
            this.valor = valor;
            this.numero = numero;
            this.descricao = descricao;
        }
    }
}
