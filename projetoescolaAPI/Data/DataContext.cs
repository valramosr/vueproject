
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using projetoescolaAPI.Models;

namespace projetoescolaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
            .HasData(
             new List<Professor>(){
                new Professor(){
                   Id = 1,
                   Nome = "João"
                 },
                new Professor(){
                   Id = 2,
                   Nome = "Marcelo"
                },
                new Professor(){
                   Id = 3,
                  Nome = "Antônio"
                }
            }
           );

           builder.Entity<Aluno>()
            .HasData(
             new List<Aluno>(){
                new Aluno(){
                  Id = 1,
                  Nome = "Valdemi",
                  Sobrenome = "Ramos",
                  DataNasc = "18/09/1971",
                  ProfessorId = 1
                 },
                new Aluno(){
                  Id = 2,
                  Nome = "Andre",
                  Sobrenome = "Silva",
                  DataNasc = "10/09/1980",
                  ProfessorId = 1
                },
                new Aluno(){
                  Id = 3,
                  Nome = "Maria",
                  Sobrenome = "Galvão",
                  DataNasc = "09/08/1988",
                  ProfessorId = 2
                },
                new Aluno(){
                  Id = 4,
                  Nome = "Dalton",
                  Sobrenome = "Chupeta",
                  DataNasc = "08/10/19 70",
                  ProfessorId = 3

                }
            }
           );
        }
    }


}