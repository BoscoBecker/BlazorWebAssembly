using BlazorClientes.Shared.Entities;

namespace BlazorClientes.Shared.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> AddClienteAsync(Cliente Model);
        Task<Cliente> UpdateClienteAsync(Cliente Model);
        Task<Cliente> DeleteClienteAsync(int clienteId);
        Task<List<Cliente>> GetAllCLientesAsync();
        Task<Cliente> GetCLienteByID(int clienteId);

    }
}
