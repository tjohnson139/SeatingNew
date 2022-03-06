using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Seating.Models
{
    public partial class db_a7e17a_seatingContext : DbContext
    {
        public db_a7e17a_seatingContext()
        {
        }

        public db_a7e17a_seatingContext(DbContextOptions<db_a7e17a_seatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<Dth> Dths { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Lunch> Lunches { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Reason> Reasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Break>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Breaks_EmployeeId");

                entity.HasOne(d => d.EmpPositionNavigation)
                    .WithMany(p => p.BreakEmpPositionNavigations)
                    .HasForeignKey(d => d.EmpPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Breaks__EmpPosit__0C50D423");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Breaks)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.RlfPositionNavigation)
                    .WithMany(p => p.BreakRlfPositionNavigations)
                    .HasForeignKey(d => d.RlfPosition)
                    .HasConstraintName("FK__Breaks__RlfPosit__0E391C95");
            });

            modelBuilder.Entity<Dth>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Dths_EmployeeId");

                entity.HasOne(d => d.EmpPositionNavigation)
                    .WithMany(p => p.DthEmpPositionNavigations)
                    .HasForeignKey(d => d.EmpPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dths__EmpPositio__10216507");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dths)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.RlfPositionNavigation)
                    .WithMany(p => p.DthRlfPositionNavigations)
                    .HasForeignKey(d => d.RlfPosition)
                    .HasConstraintName("FK__Dths__RlfPositio__0F2D40CE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DisplayName).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Lunch>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Lunches_EmployeeId");

                entity.HasIndex(e => e.ReasonId, "IX_Lunches_ReasonId");

                entity.HasOne(d => d.EmpPositionNavigation)
                    .WithMany(p => p.LunchEmpPositionNavigations)
                    .HasForeignKey(d => d.EmpPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lunches__EmpPosi__11158940");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Lunches)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Reason)
                    .WithMany(p => p.Lunches)
                    .HasForeignKey(d => d.ReasonId);

                entity.HasOne(d => d.RlfPositionNavigation)
                    .WithMany(p => p.LunchRlfPositionNavigations)
                    .HasForeignKey(d => d.RlfPosition)
                    .HasConstraintName("FK__Lunches__RlfPosi__1209AD79");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.Property(e => e.ReasonName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
