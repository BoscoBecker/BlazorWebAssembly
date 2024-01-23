using BlazorClientes.Context;
using BlazorClientes.Shared.Entities;
using BlazorClientes.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorClientes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;
        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<Cliente> AddClienteAsyc(Cliente model)
        {
            if (model is null) return null;
            var chk = await _context.Clientes.Where(_ => _.Nome.ToLower()
                                                    .Equals(model.Nome.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null;
            var novoCliente = _context.Clientes.Add(model).Entity;
            await _context.SaveChangesAsync();
            return novoCliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente model)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(_ => _.ID == model.ID);
            if (cliente is null) return null;
            cliente.Nome = model.Nome;
            cliente.Email = model.Email;
            await _context.SaveChangesAsync();
            return await _context.Clientes.FirstOrDefaultAsync(_ => _.ID == model.ID)!;
        }

        public async Task<Cliente> DeleteClienteAsync(int clienteId)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(_ => _.ID == clienteId);
            if (cliente is null) return null;
            
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;

        }
        public async Task<List<Cliente>> GetAllCLientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetCLienteByID(int clienteId)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(_ => _.ID == clienteId);
            if (cliente is null) return null;
            return cliente;
        }
    }
}
