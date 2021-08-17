using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Show__table.Models.DB
{
    public partial class MenuDBContext : DbContext
    {
        public MenuDBContext()
        {
        }

        public MenuDBContext(DbContextOptions<MenuDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupMenusTbl> GroupMenusTbls { get; set; }
        public virtual DbSet<ListMenusTbl> ListMenusTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MenuDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<GroupMenusTbl>(entity =>
            {
                entity.ToTable("groupMenus_tbl");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GroupNameMenu).HasMaxLength(20);
            });

            modelBuilder.Entity<ListMenusTbl>(entity =>
            {
                entity.ToTable("ListMenus_tbl");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.MenusName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
