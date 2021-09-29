﻿// <auto-generated />
using ECocktails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECocktails.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECocktails.Models.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("ECocktails.Models.Barman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Barmans");
                });

            modelBuilder.Entity("ECocktails.Models.Cocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<int>("BarmanId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.HasIndex("BarmanId");

                    b.HasIndex("GlassId");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Glass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Glass");
                });

            modelBuilder.Entity("ECocktails.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ECocktails.Models.Ingredients_Cocktails", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("CocktailId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("IngredientId", "CocktailId");

                    b.HasIndex("CocktailId");

                    b.ToTable("Ingredients_Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Cocktail", b =>
                {
                    b.HasOne("ECocktails.Models.Bar", "Bar")
                        .WithMany("Cocktails")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECocktails.Models.Barman", "Barman")
                        .WithMany("Cocktails")
                        .HasForeignKey("BarmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECocktails.Models.Glass", "Glass")
                        .WithMany("Cocktails")
                        .HasForeignKey("GlassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bar");

                    b.Navigation("Barman");

                    b.Navigation("Glass");
                });

            modelBuilder.Entity("ECocktails.Models.Ingredients_Cocktails", b =>
                {
                    b.HasOne("ECocktails.Models.Cocktail", "Cocktail")
                        .WithMany("Ingredients_Cocktails")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECocktails.Models.Ingredient", "Ingredient")
                        .WithMany("Ingredients_Cocktails")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cocktail");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("ECocktails.Models.Bar", b =>
                {
                    b.Navigation("Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Barman", b =>
                {
                    b.Navigation("Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Cocktail", b =>
                {
                    b.Navigation("Ingredients_Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Glass", b =>
                {
                    b.Navigation("Cocktails");
                });

            modelBuilder.Entity("ECocktails.Models.Ingredient", b =>
                {
                    b.Navigation("Ingredients_Cocktails");
                });
#pragma warning restore 612, 618
        }
    }
}
