using Microsoft.EntityFrameworkCore;
using WebApplication_DIO.Models;

namespace WebApplication_DIO.Context
{
	public class AgendaContext: DbContext
	{
        public AgendaContext(DbContextOptions<AgendaContext> options): base(options) 
        {
            
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
