using DisciplinaProfessorAPI.Models;
using DisciplinaProfessorAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace DisciplinaProfessorAPI.Controllers {
    [ApiController]
    [Route("/api/v1[controller]")]
    public class DisciplinaControler : ControllerBase {
        private IDisciplinaService _service;
        public DisciplinaControler(IDisciplinaService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> Get() {
            var listaDisciplinas = await _service.GetAllAsync();

            return Results.Ok(listaDisciplinas);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(String id) {
            var listaDisciplinas = await _service.GetByIdAsync(id);
            if (listaDisciplinas == null) {
                return Results.NotFound();
            }
            return Results.Ok(listaDisciplinas);
        }

        [HttpPost()]
        public async Task<IResult> InsertNew(Disciplina disciplina) {
            if (disciplina == null) {
                return Results.BadRequest();
            }
            await _service.saveNewAsync(disciplina);

            return Results.Ok(disciplina);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(string id, Disciplina disciplina) {
            if (disciplina == null || id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            disciplina = await _service.updateAsync(id, disciplina);

            if (disciplina == null) {
                return Results.NotFound();
            }

            return Results.Ok(disciplina);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(string id) {
            if (id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            var disciplina = await _service.DeleteAsync(id);

            if (disciplina == null) {
                return Results.NotFound();
            }

            return Results.Ok(disciplina);
        }

    }
}
