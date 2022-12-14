// <auto-generated />
using System;
using FinancialApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221130191312_Financial")]
    partial class Financial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinancialApp.Models.BankingTransaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("cost_fixed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("description2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("recipient1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("recipient2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("uniqe_key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("value")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("bankingtransactions");
                });

            modelBuilder.Entity("FinancialApp.Models.TransactionCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("transactioncategories");
                });
#pragma warning restore 612, 618
        }
    }
}
