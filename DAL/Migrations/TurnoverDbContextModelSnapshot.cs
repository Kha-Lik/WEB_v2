﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dal.Migrations
{
    [DbContext(typeof(TurnoverDbContext))]
    partial class TurnoverDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Commodity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Commodities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bread",
                            Price = 20
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wine",
                            Price = 150
                        });
                });

            modelBuilder.Entity("DAL.Entities.CommodityInShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommodityId")
                        .HasColumnType("int");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("ShopId");

                    b.ToTable("CommoditiesInShop");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommodityId = 1,
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommodityId = 2,
                            ShopId = 2
                        });
                });

            modelBuilder.Entity("DAL.Entities.CommodityInWarehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommodityId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("CommoditiesInWarehouse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommodityId = 2,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommodityId = 1,
                            WarehouseId = 2
                        });
                });

            modelBuilder.Entity("DAL.Entities.OrdersCommodities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommodityId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseElements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommodityId = 1,
                            PurchaseOrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommodityId = 2,
                            PurchaseOrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            CommodityId = 1,
                            PurchaseOrderId = 2
                        },
                        new
                        {
                            Id = 4,
                            CommodityId = 2,
                            PurchaseOrderId = 2
                        });
                });

            modelBuilder.Entity("DAL.Entities.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("PurchaseOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 4, 14, 23, 11, 23, 451, DateTimeKind.Local).AddTicks(3540),
                            Name = "Sample order",
                            Number = 1001
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2020, 4, 14, 23, 11, 23, 454, DateTimeKind.Local).AddTicks(7434),
                            Name = "Second sample order",
                            Number = 10011001
                        });
                });

            modelBuilder.Entity("DAL.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ATB"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rozetka"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "First warehouse"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Second warehouse"
                        });
                });

            modelBuilder.Entity("DAL.Entities.CommodityInShop", b =>
                {
                    b.HasOne("DAL.Entities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.CommodityInWarehouse", b =>
                {
                    b.HasOne("DAL.Entities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.OrdersCommodities", b =>
                {
                    b.HasOne("DAL.Entities.Commodity", "Commodity")
                        .WithMany("Orders")
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Commodities")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("DAL.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("DAL.Entities.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
