namespace SimpleAuthMember.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<route> routes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<route>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<route>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<webpages_Roles>()
                .HasMany(e => e.routes)
                .WithMany(e => e.webpages_Roles)
                .Map(m => m.ToTable("RolesInRoutes").MapLeftKey("IdRole").MapRightKey("IdRoute"));

            modelBuilder.Entity<webpages_Roles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.webpages_Roles)
                .Map(m => m.ToTable("webpages_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
