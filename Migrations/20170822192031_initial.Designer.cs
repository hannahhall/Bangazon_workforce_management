using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BangazonHR.Data;

namespace BangazonHR.Migrations
{
    [DbContext(typeof(BangazonContext))]
    [Migration("20170822192031_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BangazonHR.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DecomissionDate");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("BangazonHR.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BangazonHR.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsSupervisor");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BangazonHR.Models.TrainingEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingProgramId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingEmployee");
                });

            modelBuilder.Entity("BangazonHR.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("BangazonHR.Models.Computer", b =>
                {
                    b.HasOne("BangazonHR.Models.Employee", "Employee")
                        .WithMany("Computers")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("BangazonHR.Models.Employee", b =>
                {
                    b.HasOne("BangazonHR.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangazonHR.Models.TrainingEmployee", b =>
                {
                    b.HasOne("BangazonHR.Models.Employee", "Employee")
                        .WithMany("TrainingEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BangazonHR.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingEmployees")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
