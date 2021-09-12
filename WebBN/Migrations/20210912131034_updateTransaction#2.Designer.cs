﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBN.Data;

namespace WebBN.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210912131034_updateTransaction#2")]
    partial class updateTransaction2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebBN.Models.SetupFee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FeeRate")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("SetupFees");
                });

            modelBuilder.Entity("WebBN.Models.TansactionLog", b =>
                {
                    b.Property<string>("TranID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("AmountAfterFee")
                        .HasColumnType("float");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("IBAN_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToIBAN_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Types")
                        .HasColumnType("int");

                    b.HasKey("TranID");

                    b.ToTable("TansactionLogs");
                });

            modelBuilder.Entity("WebBN.Models.UserAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Deposit_Amount")
                        .HasColumnType("float");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
