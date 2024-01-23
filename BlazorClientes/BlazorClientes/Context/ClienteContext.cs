using Microsoft.EntityFrameworkCore;
using BlazorClientes.Shared.Entities;

namespace BlazorClientes.Context
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes {  get; set; }
    }
}
