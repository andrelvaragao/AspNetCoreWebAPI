using WebAPIv6.Models;

namespace WebAPIv6.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        bool SaveChanges();
        //Alunos
        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAlunos);
        Professor[] GetAllProfessoresByDIsciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);

        
    }
}