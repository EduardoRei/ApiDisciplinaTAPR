using DisciplinaProfessorAPI.Models;

namespace DisciplinaProfessorAPI.Services {
    public interface IDisciplinaService {
        Task<List<Disciplina>> GetAllAsync();
        Task<Disciplina> GetByIdAsync(string id);
        Task<Disciplina> saveNewAsync(Disciplina disciplina);
        Task<Disciplina> updateAsync(string id, Disciplina disciplina);
        Task<Disciplina> DeleteAsync(string id);
    }
}
