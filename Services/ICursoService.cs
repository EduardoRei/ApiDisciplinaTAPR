using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAPR_Disciplina.Models;

namespace TAPR_Curso.Services
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