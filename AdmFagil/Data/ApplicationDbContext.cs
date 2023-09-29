using AdmFagil.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmFagil.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ServicoModel> Servico { get; set; }
    }
}
