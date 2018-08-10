﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mvc.Data;

namespace Ale.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mvc.Models.Employees", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FullName");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Mvc.Models.General", b =>
                {
                    b.Property<int>("GenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company_name");

                    b.Property<string>("From_where");

                    b.Property<string>("Name_of_company");

                    b.Property<string>("Name_of_event");

                    b.Property<string>("Purpose");

                    b.Property<DateTime>("Sign_in");

                    b.Property<string>("To_whom");

                    b.Property<int>("UserId");

                    b.Property<string>("Whom_to_see");

                    b.HasKey("GenId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Generals");
                });

            modelBuilder.Entity("Mvc.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Company_name");

                    b.Property<string>("Email");

                    b.Property<string>("From_where");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Name_of_company");

                    b.Property<string>("Name_of_event");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Purpose")
                        .IsRequired();

                    b.Property<DateTime>("Sign_in");

                    b.Property<string>("To_whom");

                    b.Property<string>("Whom_to_see");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mvc.Models.General", b =>
                {
                    b.HasOne("Mvc.Models.User", "User")
                        .WithOne("general")
                        .HasForeignKey("Mvc.Models.General", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
