using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services
{
    public class ProfessorService : IProfessorService
    {
        public Task<Professor> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Professor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Professor> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> saveNewAsync(Professor professor)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> updateAsync(string id, Professor professor)
        {
            throw new NotImplementedException();
        }
    }
}