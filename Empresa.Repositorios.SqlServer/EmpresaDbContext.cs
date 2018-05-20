﻿using Empresa.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Repositorios.SqlServer
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}