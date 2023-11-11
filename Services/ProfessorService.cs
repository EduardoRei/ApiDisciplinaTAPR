using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services
{
    public class ProfessorService : IProfessorService
    {
        private RepositoryDbContext _dbContext;
        public ProfessorService(RepositoryDbContext dbContext)
        {
            this._dbContext = dbContext;  
        }
        public async Task<Professor> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            var listaProfessores = await _dbContext.Professores.ToListAsync();
            return listaProfessores;
        }

        public async Task<Professor> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> saveNewAsync(Professor professor)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> updateAsync(string id, Professor professor)
        {
            throw new NotImplementedException();
        }
    }
}