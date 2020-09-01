using System.Threading.Tasks;
using projetoescolaAPI.Models;

namespace projetoescolaAPI.Data
{
    public interface IRepository
      {
        //gerais

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Alunos
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAllAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAllAlunosAsyncById(int AlunoId, bool includeProfessor);

        //Professor
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetAllProfessoresById(int ProfessorId, bool includeAluno);
   }
}