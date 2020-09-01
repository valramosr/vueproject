﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using projetoescolaAPI.Data;

namespace projetoescolaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("projetoescolaAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DataNasc")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("integer");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "18/09/1971",
                            Nome = "Valdemi",
                            ProfessorId = 1,
                            Sobrenome = "Ramos"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "10/09/1980",
                            Nome = "Andre",
                            ProfessorId = 1,
                            Sobrenome = "Silva"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "09/08/1988",
                            Nome = "Maria",
                            ProfessorId = 2,
                            Sobrenome = "Galvão"
                        },
                        new
                        {
                            Id = 4,
                            DataNasc = "08/10/19 70",
                            Nome = "Dalton",
                            ProfessorId = 3,
                            Sobrenome = "Chupeta"
                        });
                });

            modelBuilder.Entity("projetoescolaAPI.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "João"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Marcelo"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Antônio"
                        });
                });

            modelBuilder.Entity("projetoescolaAPI.Models.Aluno", b =>
                {
                    b.HasOne("projetoescolaAPI.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
