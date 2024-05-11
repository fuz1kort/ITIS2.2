﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonsAPI.Data;

#nullable disable

namespace PokemonsAPI.Data.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Breeding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Breedings");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Ability", b =>
                {
                    b.HasOne("PokemonsAPI.Core.Entities.Pokemon", null)
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Breeding", b =>
                {
                    b.HasOne("PokemonsAPI.Core.Entities.Pokemon", null)
                        .WithOne("Breeding")
                        .HasForeignKey("PokemonsAPI.Core.Entities.Breeding", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Move", b =>
                {
                    b.HasOne("PokemonsAPI.Core.Entities.Pokemon", null)
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Stat", b =>
                {
                    b.HasOne("PokemonsAPI.Core.Entities.Pokemon", null)
                        .WithMany("Stats")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Type", b =>
                {
                    b.HasOne("PokemonsAPI.Core.Entities.Pokemon", null)
                        .WithMany("Types")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonsAPI.Core.Entities.Pokemon", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Breeding");

                    b.Navigation("Moves");

                    b.Navigation("Stats");

                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}
