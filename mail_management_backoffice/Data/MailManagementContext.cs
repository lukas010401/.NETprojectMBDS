using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mail_management_backoffice.Data
{
    public class MailManagementContext : IdentityDbContext
    {
        public MailManagementContext (DbContextOptions<MailManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Mail> Mails { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mail>().ToTable("Mails");
        }*/
    }
}
