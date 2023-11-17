
using TAPR_Disciplina.Models;
using TAPR_Disciplina.Services;
using Microsoft.AspNetCore.Mvc;


namespace TAPR_Disciplina.Controllers {
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DisciplinaController : ControllerBase {
        private IDisciplinaService _service;
        public DisciplinaController(IDisciplinaService service)
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
        public async Task<IResult> InsertNew(string nomeDisciplina,string cargaHoraria, string diasAula, string idProfessor, string idCurso) {
            var professor = await _service.GetProfessorByIdAsync(idProfessor);
            if (professor == null){
                return Results.BadRequest();
            }
            var curso = await _service.GetCursoByIdAsync(idCurso);
            if(curso == null){
                return Results.BadRequest();
            }
            Guid aux = new Guid();
            var disciplina = new Disciplina(aux, nomeDisciplina,cargaHoraria,diasAula,professor,curso);
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
