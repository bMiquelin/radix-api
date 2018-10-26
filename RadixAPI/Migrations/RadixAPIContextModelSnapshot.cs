﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RadixAPI.Data;

namespace RadixAPI.Migrations
{
    [DbContext(typeof(RadixAPIContext))]
    partial class RadixAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RadixAPI.Model.Entity.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("API_KEY");

                    b.Property<bool>("AntiFraud");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("RadixAPI.Model.Entity.StoreGatewayRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasMaxLength(10);

                    b.Property<int>("Gateway");

                    b.Property<int>("Priority");

                    b.Property<Guid>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreGatewayRule");
                });

            modelBuilder.Entity("RadixAPI.Model.Entity.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Brand");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Gateway");

                    b.Property<string>("Holder");

                    b.Property<string>("LastDigits");

                    b.Property<bool>("NeedAntiFraud");

                    b.Property<Guid?>("StoreId");

                    b.Property<bool>("Success");

                    b.Property<bool>("SuccessAntiFraud");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("RadixAPI.Model.Entity.StoreGatewayRule", b =>
                {
                    b.HasOne("RadixAPI.Model.Entity.Store", "Store")
                        .WithMany("StoreGatewayRules")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RadixAPI.Model.Entity.Transaction", b =>
                {
                    b.HasOne("RadixAPI.Model.Entity.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });
#pragma warning restore 612, 618
        }
    }
}
