using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleServicoAPI.Data;
using ControleServicoAPI.Models;
using ControleServicoAPI.services;
using Microsoft.EntityFrameworkCore;

public class ClienteService : IClienteService
{
    private readonly DataContext _dataContext;

    public ClienteService(DataContext dataContext)
    {
        _dataContext = dataContext;
        
    }

    public async Task<List<Cliente>> GetAllClientes()
    {
        return await _dataContext.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetSingleCliente(int id)
    {
        return await _dataContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCliente(Cliente cliente)
    {
        _dataContext.Clientes.Add(cliente);
        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateCliente(int id, Cliente request)
    {
        var clienteExistente = await _dataContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        if (clienteExistente != null)
        {
            clienteExistente.Name = request.Name;
            clienteExistente.Numero = request.Numero;

            await _dataContext.SaveChangesAsync();
        }
    }

    public async Task DeleteCliente(int id)
    {
        var clienteExistente = await _dataContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        if (clienteExistente != null)
        {
            _dataContext.Clientes.Remove(clienteExistente);
            await _dataContext.SaveChangesAsync();
        }
    }
}
