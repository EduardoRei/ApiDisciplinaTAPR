using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services
{
    public interface ICursoService
    {
        Task<List<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(string id);
        Task<Curso> saveNewAsync(Curso curso);
        Task<Curso> updateAsync(string id, Curso curso);
        Task<Curso> DeleteAsync(string id);
    }
}