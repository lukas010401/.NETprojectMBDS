using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace mail_management_backoffice.Data
{
    public class MailManagementContext : IdentityDbContext
    {
        public MailManagementContext (DbContextOptions<MailManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Mail> Mails { get; set; }
        public DbSet<Recipient> Recipient { get; set; }
        //public DbSet<MailRecipient> MailRecipient { get; set; }

        public DbSet<mail_management_backoffice.Models.ChangeHistory> ChangeHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mail>()
            .HasMany(m => m.Recipients)
            .WithMany(r => r.Mails)
            .UsingEntity<Dictionary<string, object>>(
                "MailRecipient",
                j => j
                    .HasOne<Recipient>()
                    .WithMany()
                    .HasForeignKey("RecipientID"),
                j => j
                    .HasOne<Mail>()
                    .WithMany()
                    .HasForeignKey("MailID"),
                j =>
                {
                    j.HasKey("MailID", "RecipientID");
                    j.ToTable("MailRecipient");
                });

            // Autres configurations

            base.OnModelCreating(modelBuilder);
        }
    }
}
