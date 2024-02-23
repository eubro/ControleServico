using ControleServicoAPI.Models;

namespace ControleServicoAPI.services
{
    public interface IClienteService
    {
        public interface IClienteService
        {
            Task<List<Cliente>> GetAllClientes();
            Task<Cliente?> GetSingleCliente(string id);
            Task AddCliente(Cliente cliente);
            Task UpdateCliente(string id, Cliente request);
            Task DeleteCliente(string id);
        }

    }
}
