using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAPR_Disciplina.Models;
using TAPR_Curso.Services;

namespace TAPR_Disciplina.Services
{
    public class CursoService : ICursoService
    {
        public Task<Curso> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Curso>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Curso> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> saveNewAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> updateAsync(string id, Curso curso)
        {
            throw new NotImplementedException();
        }
    }
}