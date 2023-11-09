using DisciplinaProfessorAPI.Models;

namespace DisciplinaProfessorAPI.Services {
    public class DisciplinaService : IDisciplinaService {
        private RepositoryDbContext _dbContext;
        public DisciplinaService(RepositoryDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public Task<Disciplina> DeleteAsync(string id) {
            throw new NotImplementedException();
        }

        public Task<List<Disciplina>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Disciplina> GetByIdAsync(string id) {
            throw new NotImplementedException();
        }

        public Task<Disciplina> saveNewAsync(Disciplina disciplina) {
            throw new NotImplementedException();
        }

        public Task<Disciplina> updateAsync(string id, Disciplina disciplina) {
            throw new NotImplementedException();
        }
    }
}
