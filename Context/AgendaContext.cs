using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
            //recebe a conexão do banco e passa para o base
        }

        public DbSet<Contato> Contatos { get; set; } //representa tabela
        //entidade: classe no programa, e tabela no banco de dados
    }
}