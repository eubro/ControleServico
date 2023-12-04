using ControleServicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleServicoAPI.services
{
    public class CadServicoService : IControleServico
    {
        private readonly DataContext _dataContext;

        public CadServicoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<CadServico>> AddServico(CadServico servico)
        {
            servico.Concluido = false;
            _dataContext.CadServicos.Add(servico);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.CadServicos.ToListAsync();
        }

        public async Task<List<CadServico>?> DeleteServico(int id)
        {
            var servico = await _dataContext.CadServicos.FindAsync(id);
            if (servico == null)
            
                return null;
            _dataContext.CadServicos.Remove(servico);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.CadServicos.ToListAsync();
            
        }

        public async Task<List<CadServico>> GetAllServicos()
        {
            var servico = await _dataContext.CadServicos.ToListAsync();
            return servico;
        }

        public async Task<CadServico?> GetSingleServico(int id)
        {
            var servico = await _dataContext.CadServicos.FindAsync(id);
            if(servico == null)
                return null;

            return servico;
        }

        public async Task<List<CadServico>?> UpdateServico(int id, CadServico request)
        {
            var servico = await _dataContext.CadServicos.FindAsync(id);
            if(servico == null)
                return null;

            servico.Nome = request.Nome;
            servico.Numero = request.Numero;
            servico.Valor = request.Valor;
            servico.Descricao = request.Descricao;
            servico.Concluido = request.Concluido;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.CadServicos.ToListAsync();
        }

        public async Task<List<CadServico>> MarcarComoConcluido(int id)
        {
            var servico = await _dataContext.CadServicos.FindAsync(id);
            if (servico == null)
                return null;

            servico.Concluido = true;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.CadServicos.ToListAsync();
        }


    }
}
