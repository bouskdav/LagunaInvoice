using System;
using System.Collections.Generic;
using System.Text;
using LagunaInvoice.Portal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LagunaInvoice.Portal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<IssuedInvoice> IssuedInvoices { get; set; }
        public virtual DbSet<IssuedInvoiceItem> IssuedInvoiceItems { get; set; }
        public virtual DbSet<IssuedInvoicePayment> IssuedInvoicePayments { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserCompany>().HasKey(i => new { i.ApplicationUserID, i.CompanyID });

            // Shorten key length for Identity
            builder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Id).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
            });

            builder.Entity<IdentityRole>(entity => {
                entity.Property(m => m.Id).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });

            builder.Entity<IdentityUserLogin<string>>(entity => {
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
                entity.Property(m => m.UserId).HasMaxLength(127);
            });

            builder.Entity<IdentityUserRole<string>>(entity => {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.RoleId).HasMaxLength(127);
            });

            builder.Entity<IdentityUserToken<string>>(entity => {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);
            });

            builder.Entity<IdentityUserClaim<string>>(entity => {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.Id).HasMaxLength(127);
            });

            builder.Entity<IdentityRoleClaim<string>>(entity => {
                entity.Property(m => m.RoleId).HasMaxLength(127);
                entity.Property(m => m.Id).HasMaxLength(127);
            });
        }
    }
}
