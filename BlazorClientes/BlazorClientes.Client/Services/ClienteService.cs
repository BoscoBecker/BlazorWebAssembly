using BlazorClientes.Shared.Entities;
using BlazorClientes.Shared.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorClientes.Client.Services
{
    public class ClienteService : IClienteRepository
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions _options;

        public ClienteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<Cliente> AddClienteAsync(Cliente model)
        {
            var cliente = await httpClient.PostAsJsonAsync("api/CLiente/Add-Cliente", model);
            return await cliente.Content.ReadFromJsonAsync<Cliente>();
        }
        public async Task<Cliente> DeleteClienteAsync(int clienteId)
        {
            var cliente = await httpClient.DeleteAsync($"api/Delete-Cliente/{clienteId}");
            return await cliente.Content.ReadFromJsonAsync<Cliente>();
        }
        public async Task<List<Cliente>> GetAllCLientesAsync()
        {
            var cliente = await httpClient.GetAsync("api/Cliente/Clientes");
            return await cliente.Content.ReadFromJsonAsync<List<Cliente>>();
        }
        public async Task<Cliente> GetCLienteByID(int clienteId)
        {
            var cliente = await httpClient.GetAsync($"api/cliente/{clienteId}");
            return await cliente.Content.ReadFromJsonAsync<Cliente>();
        }
        public async Task<Cliente> UpdateClienteAsync(Cliente model)
        {
            var cliente = await httpClient.PutAsJsonAsync("api/Update-Cliente", model);
            return await cliente.Content.ReadFromJsonAsync<Cliente>();
        }
    }
}
