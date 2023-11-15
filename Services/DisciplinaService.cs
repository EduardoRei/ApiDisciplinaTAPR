using Microsoft.EntityFrameworkCore;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services {
    public class DisciplinaService : IDisciplinaService {
        private RepositoryDbContext _dbContext;
        public DisciplinaService(RepositoryDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public async Task<Disciplina> DeleteAsync(string id) {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<Disciplina> updateAsync(string id, Disciplina disciplina) {
            throw new NotImplementedException();
        }
    }
}
