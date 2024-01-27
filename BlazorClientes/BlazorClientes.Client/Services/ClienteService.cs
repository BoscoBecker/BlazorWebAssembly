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

        public async Task<Cliente> AddClienteAsyc(Cliente model)
        {
            var cliente = await httpClient.PostAsJsonAsync("api/CLiente/Add-Cliente", model);
            //var response = await cliente.Content.ReadFromJsonAsync<Cliente>();
            return await cliente.Content.ReadFromJsonAsync<Cliente>();
        }

        public Task<Cliente> DeleteClienteAsync(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetAllCLientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetCLienteByID(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> UpdateClienteAsync(Cliente Model)
        {
            throw new NotImplementedException();
        }
    }
}
