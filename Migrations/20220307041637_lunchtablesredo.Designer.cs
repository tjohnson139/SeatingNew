// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seating.Models;

namespace Seating.Migrations
{
    [DbContext(typeof(db_a7e17a_seatingContext))]
    [Migration("20220307041637_lunchtablesredo")]
    partial class lunchtablesredo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Seating.Models.Break", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpPosition")
                        .HasColumnType("int");

                    b.Property<bool?>("EmpSent")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("RlfPosition")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeCleared")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeEntered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpPosition");

                    b.HasIndex("RlfPosition");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Breaks_EmployeeId");

                    b.ToTable("Breaks");
                });

            modelBuilder.Entity("Seating.Models.Dth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpPosition")
                        .HasColumnType("int");

                    b.Property<bool?>("EmpSent")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("RlfPosition")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeCleared")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeEntered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpPosition");

                    b.HasIndex("RlfPosition");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Dths_EmployeeId");

                    b.ToTable("Dths");
                });

            modelBuilder.Entity("Seating.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DispatchNumber")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmployed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Schedules")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Seating.Models.Lunch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpPosition")
                        .HasColumnType("int");

                    b.Property<bool?>("EmpSent")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool?>("LongerLunch")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LunchTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReasonId")
                        .HasColumnType("int");

                    b.Property<int?>("RlfPosition")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeCleared")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeEntered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpPosition");

                    b.HasIndex("RlfPosition");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Lunches_EmployeeId");

                    b.HasIndex(new[] { "ReasonId" }, "IX_Lunches_ReasonId");

                    b.ToTable("Lunches");
                });

            modelBuilder.Entity("Seating.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Seating.Models.Reason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reasons");
                });

            modelBuilder.Entity("Seating.Models.Break", b =>
                {
                    b.HasOne("Seating.Models.Position", "EmpPositionNavigation")
                        .WithMany("BreakEmpPositionNavigations")
                        .HasForeignKey("EmpPosition")
                        .HasConstraintName("FK__Breaks__EmpPosit__0C50D423")
                        .IsRequired();

                    b.HasOne("Seating.Models.Employee", "Employee")
                        .WithMany("Breaks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Seating.Models.Position", "RlfPositionNavigation")
                        .WithMany("BreakRlfPositionNavigations")
                        .HasForeignKey("RlfPosition")
                        .HasConstraintName("FK__Breaks__RlfPosit__0E391C95");

                    b.Navigation("Employee");

                    b.Navigation("EmpPositionNavigation");

                    b.Navigation("RlfPositionNavigation");
                });

            modelBuilder.Entity("Seating.Models.Dth", b =>
                {
                    b.HasOne("Seating.Models.Position", "EmpPositionNavigation")
                        .WithMany("DthEmpPositionNavigations")
                        .HasForeignKey("EmpPosition")
                        .HasConstraintName("FK__Dths__EmpPositio__10216507")
                        .IsRequired();

                    b.HasOne("Seating.Models.Employee", "Employee")
                        .WithMany("Dths")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Seating.Models.Position", "RlfPositionNavigation")
                        .WithMany("DthRlfPositionNavigations")
                        .HasForeignKey("RlfPosition")
                        .HasConstraintName("FK__Dths__RlfPositio__0F2D40CE");

                    b.Navigation("Employee");

                    b.Navigation("EmpPositionNavigation");

                    b.Navigation("RlfPositionNavigation");
                });

            modelBuilder.Entity("Seating.Models.Lunch", b =>
                {
                    b.HasOne("Seating.Models.Position", "EmpPositionNavigation")
                        .WithMany("LunchEmpPositionNavigations")
                        .HasForeignKey("EmpPosition")
                        .HasConstraintName("FK__Lunches__EmpPosi__11158940")
                        .IsRequired();

                    b.HasOne("Seating.Models.Employee", "Employee")
                        .WithMany("Lunches")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Seating.Models.Reason", "Reason")
                        .WithMany("Lunches")
                        .HasForeignKey("ReasonId");

                    b.HasOne("Seating.Models.Position", "RlfPositionNavigation")
                        .WithMany("LunchRlfPositionNavigations")
                        .HasForeignKey("RlfPosition")
                        .HasConstraintName("FK__Lunches__RlfPosi__1209AD79");

                    b.Navigation("Employee");

                    b.Navigation("EmpPositionNavigation");

                    b.Navigation("Reason");

                    b.Navigation("RlfPositionNavigation");
                });

            modelBuilder.Entity("Seating.Models.Employee", b =>
                {
                    b.Navigation("Breaks");

                    b.Navigation("Dths");

                    b.Navigation("Lunches");
                });

            modelBuilder.Entity("Seating.Models.Position", b =>
                {
                    b.Navigation("BreakEmpPositionNavigations");

                    b.Navigation("BreakRlfPositionNavigations");

                    b.Navigation("DthEmpPositionNavigations");

                    b.Navigation("DthRlfPositionNavigations");

                    b.Navigation("LunchEmpPositionNavigations");

                    b.Navigation("LunchRlfPositionNavigations");
                });

            modelBuilder.Entity("Seating.Models.Reason", b =>
                {
                    b.Navigation("Lunches");
                });
#pragma warning restore 612, 618
        }
    }
}
