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
            var cursoAntigo = await _dbContext.Cursos.Where(c => c.idCurso.Equals(new Guid(id))).FirstOrDefaultAsync();
            if(cursoAntigo != null){
                _dbContext.Remove(cursoAntigo);
                await _dbContext.SaveChangesAsync();
            }
            return cursoAntigo;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            var listaCursos = await _dbContext.Cursos.ToListAsync();
            return listaCursos;
        }

        public async Task<Curso> GetByIdAsync(string id)
        {
            var curso = await _dbContext.Cursos.Where(c => c.idCurso.Equals(new Guid(id))).FirstOrDefaultAsync();
            return curso;
        }

        public async Task<Curso> saveNewAsync(Curso curso)
        {
            curso.idCurso = Guid.Empty;
            await _dbContext.Cursos.AddAsync(curso);
            await _dbContext.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> updateAsync(string id, Curso curso)
        {
            var cursoAntigo = await _dbContext.Cursos.Where(c => c.idCurso.Equals(new Guid(id))).FirstOrDefaultAsync();
            if(cursoAntigo != null){
                cursoAntigo.nomeCurso = curso.nomeCurso;
                cursoAntigo.periodoCurso = curso.periodoCurso;
                await _dbContext.SaveChangesAsync();
            }
            return cursoAntigo;
        }
    }
}