using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAPR_Disciplina.Models;

namespace TAPR_Disciplina.Services
{
    public class CursoService : ICursoService
    {
        private RepositoryDbContext _dbContext;
        public CursoService(RepositoryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Curso> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            var listaCursos = await _dbContext.Cursos.ToListAsync();
            return listaCursos;
        }

        public async Task<Curso> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> saveNewAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> updateAsync(string id, Curso curso)
        {
            throw new NotImplementedException();
        }
    }
}