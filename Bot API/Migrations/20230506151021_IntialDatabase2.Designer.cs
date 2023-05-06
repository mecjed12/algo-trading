﻿// <auto-generated />
using System;
using Bot_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bot_API.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20230506151021_IntialDatabase2")]
    partial class IntialDatabase2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bot_API.EfCore.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("symbol");

                    b.HasKey("Id");

                    b.ToTable("coins");
                });

            modelBuilder.Entity("Bot_API.EfCore.Exchange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("exchange");
                });

            modelBuilder.Entity("Bot_API.Models.HistoricalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Close")
                        .HasColumnType("numeric")
                        .HasColumnName("close");

                    b.Property<decimal>("High")
                        .HasColumnType("numeric")
                        .HasColumnName("high");

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric")
                        .HasColumnName("low");

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric")
                        .HasColumnName("open");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timeStamp");

                    b.Property<int>("TradingPairId")
                        .HasColumnType("integer")
                        .HasColumnName("tradingPairId");

                    b.Property<decimal>("Volume")
                        .HasColumnType("numeric")
                        .HasColumnName("volume");

                    b.HasKey("Id");

                    b.HasIndex("TradingPairId");

                    b.ToTable("historiacalData");
                });

            modelBuilder.Entity("Bot_API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Bot_API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Bot_API.Models.TradingPair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoinId")
                        .HasColumnType("integer")
                        .HasColumnName("coinId");

                    b.Property<int>("ExchangeId")
                        .HasColumnType("integer")
                        .HasColumnName("exchangeId");

                    b.Property<int>("QuoteCoinId")
                        .HasColumnType("integer")
                        .HasColumnName("quoteCoinId");

                    b.HasKey("Id");

                    b.HasIndex("CoinId");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("QuoteCoinId");

                    b.ToTable("tradingPair");
                });

            modelBuilder.Entity("Bot_API.Models.HistoricalData", b =>
                {
                    b.HasOne("Bot_API.Models.TradingPair", "TradingPair")
                        .WithMany()
                        .HasForeignKey("TradingPairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradingPair");
                });

            modelBuilder.Entity("Bot_API.Models.Order", b =>
                {
                    b.HasOne("Bot_API.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bot_API.Models.TradingPair", b =>
                {
                    b.HasOne("Bot_API.EfCore.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bot_API.EfCore.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bot_API.EfCore.Coin", "QuoteCoin")
                        .WithMany()
                        .HasForeignKey("QuoteCoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coin");

                    b.Navigation("Exchange");

                    b.Navigation("QuoteCoin");
                });
#pragma warning restore 612, 618
        }
    }
}
