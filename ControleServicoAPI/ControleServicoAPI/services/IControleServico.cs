using ControleServicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleServicoAPI.services
{
    public interface IControleServico
    {
        Task<List<CadServico>> GetAllServicos();
        Task<CadServico?> GetSingleServico(int id);
        Task<List<CadServico>> AddServico(CadServico servico);
        Task<List<CadServico>?> UpdateServico(int id, CadServico request);
        Task<List<CadServico>?> DeleteServico(int id);
        Task<List<CadServico>> MarcarComoConcluido(int id);
    }
}
