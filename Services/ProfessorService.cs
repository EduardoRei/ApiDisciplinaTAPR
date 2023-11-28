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
            var professorAntigo = await _dbContext.Professores.Where(c => c.idProfessor.Equals(new Guid(id))).FirstOrDefaultAsync();
            if(professorAntigo != null){
                _dbContext.Remove(professorAntigo);
                await _dbContext.SaveChangesAsync();
            }
            return professorAntigo;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            var listaProfessores = await _dbContext.Professores.ToListAsync();
            return listaProfessores;
        }

        public async Task<Professor> GetByIdAsync(string id)
        {
            var professor = await _dbContext.Professores.Where(c => c.idProfessor.Equals(new Guid(id))).FirstOrDefaultAsync();
            return professor;

        }

        public async Task<Professor> saveNewAsync(Professor professor)
        {
            professor.idProfessor = Guid.Empty;
            await _dbContext.Professores.AddAsync(professor);
            await _dbContext.SaveChangesAsync();

            return professor;
        }

        public async Task<Professor> updateAsync(string id, Professor professor)
        {
            var professorAntigo = await _dbContext.Professores.Where(c => c.idProfessor.Equals(new Guid(id))).FirstOrDefaultAsync();
            if(professorAntigo != null){
                professorAntigo.nomeDoProfessor = professor.nomeDoProfessor;
                await _dbContext.SaveChangesAsync();
            }
            return professorAntigo;
        }

        public async Task<Professor> updateEventAsync(Professor professor)
        {
            var professorAntigo = await _dbContext.Professores.Where(c => c.idProfessor.Equals(professor.id)).FirstOrDefaultAsync();
            if(professorAntigo == null){
                await _dbContext.Professores.AddAsync(professor);
                await _dbContext.SaveChangesAsync();
            } else {
                await updateAsync(professor.idProfessor.ToString(),professor);
            }
            return professor;
        }
    }
}