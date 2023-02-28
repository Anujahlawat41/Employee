using System;
using Microsoft.EntityFrameworkCore;

namespace Employe.Models
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }
        public DbSet<employe> employes { get; set; }

    }
}

