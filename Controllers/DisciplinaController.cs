
using TAPR_Disciplina.Models;
using TAPR_Disciplina.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.Azure.Cosmos.Linq;


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
            var curso = await _service.GetCursoByIdAsync(idCurso);
            
            if(professor == null && curso == null){
                return Results.BadRequest("O professorId e o cursoID informados não existem!");
            }
            if (professor == null){
                return Results.BadRequest("O professorId informado, não existe!");
            }

            if(curso == null){
                return Results.BadRequest("O cursoId informado, não existe!");
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
        public async Task<IResult> Update(string id, string nomeDisciplina,string cargaHoraria, string diasAula, string idProfessor, string idCurso) {
            var disciplina = await _service.GetByIdAsync(id);
            if (disciplina == null || id.Equals(String.Empty)) {
                return Results.BadRequest();
            }
            var professor = await _service.GetProfessorByIdAsync(idProfessor);
            var curso = await _service.GetCursoByIdAsync(idCurso);
            if (nomeDisciplina != null && nomeDisciplina != "" && nomeDisciplina != " "){
                disciplina.nomeDisciplina = nomeDisciplina;
            }            
            if(cargaHoraria != null && cargaHoraria != "" && cargaHoraria != " "){
                disciplina.cargaHoraria = cargaHoraria;
            }
            if(diasAula != null && diasAula != "" && diasAula != " "){
                disciplina.diaAula = diasAula;
            }
            if(professor != null ){
                disciplina.professor = professor;

            }
            if(curso != null ){
                disciplina.curso = curso;
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
