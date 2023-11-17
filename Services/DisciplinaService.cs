using Microsoft.EntityFrameworkCore;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services {
    public class DisciplinaService : IDisciplinaService {
        private RepositoryDbContext _dbContext;
        public DisciplinaService(RepositoryDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public async Task<Professor> GetProfessorByIdAsync(string id)
        {
            var professor = await _dbContext.Professores.Where(c => c.idProfessor.Equals(new Guid(id))).FirstOrDefaultAsync();
            return professor;
        }

        public async Task<Curso> GetCursoByIdAsync(string id)
        {
            var curso = await _dbContext.Cursos.Where(c => c.idCurso.Equals(new Guid(id))).FirstOrDefaultAsync();
            return curso;
        }

        public async Task<Disciplina> DeleteAsync(string id) {
            var disciplinaAntiga = await _dbContext.Disciplinas.Where(c => c.idDisciplina.Equals(new Guid(id))).FirstOrDefaultAsync();
            if(disciplinaAntiga != null){
                _dbContext.Remove(disciplinaAntiga);
                await _dbContext.SaveChangesAsync();
            }
            return disciplinaAntiga;
        }

        public async Task<List<Disciplina>> GetAllAsync() {
            var listaDisciplinas = await _dbContext.Disciplinas.ToListAsync();
            return listaDisciplinas;
        }

        public async Task<Disciplina> GetByIdAsync(string id) {
            var disciplina = await _dbContext.Disciplinas.Where(c => c.idDisciplina.Equals(new Guid(id))).FirstOrDefaultAsync();
            return disciplina;
        }

        public async Task<Disciplina> saveNewAsync(Disciplina disciplina) {
            disciplina.idDisciplina = Guid.Empty;
 
            await _dbContext.Disciplinas.AddAsync(disciplina);
            await _dbContext.SaveChangesAsync();

            return disciplina;        
        }

        public async Task<Disciplina> updateAsync(string id, Disciplina disciplina) {
            throw new NotImplementedException();
        }
    }
}
