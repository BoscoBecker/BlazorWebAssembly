using BlazorClientesShared.Entities;

namespace BlazorClientesShared.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> AddClienteAsyc(Cliente Model);
        Task<Cliente> UpdateClienteAsync(Cliente Model);
        Task<Cliente> DeleteClienteAsync(int clienteId);
        Task<List<Cliente>> GetAllCLientesAsync();
        Task<Cliente> GetCLienteByID(int clienteId);

    }
}
