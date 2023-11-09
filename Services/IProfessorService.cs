using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services
{
    public interface IProfessorService
    {
        Task<List<Professor>> GetAllAsync();
        Task<Professor> GetByIdAsync(string id);
        Task<Professor> saveNewAsync(Professor professor);
        Task<Professor> updateAsync(string id, Professor professor);
        Task<Professor> DeleteAsync(string id);
    }
}