using Microsoft.AspNetCore.Mvc;
using TAPR_Disciplina.Models;
using TAPR_Disciplina.Services;
using Dapr;

namespace TAPR_Professor.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private IProfessorService _service;
        private IConfiguration _configuration;
        public ProfessorController(IProfessorService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> Get() {
            var listaProfessores = await _service.GetAllAsync();

            return Results.Ok(listaProfessores);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(String id) {
            var listaProfessores = await _service.GetByIdAsync(id);
            if (listaProfessores == null) {
                return Results.NotFound();
            }
            return Results.Ok(listaProfessores);
        }

        [HttpPost()]
        public async Task<IResult> InsertNew(Professor professor) {
            if (professor == null) {
                return Results.BadRequest();
            }
            await _service.saveNewAsync(professor);

            return Results.Ok(professor);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(string id, Professor professor) {
            if (professor == null || id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            professor = await _service.updateAsync(id, professor);

            if (professor == null) {
                return Results.NotFound();
            }

            return Results.Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(string id) {
            if (id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            var professor = await _service.DeleteAsync(id);

            if (professor == null) {
                return Results.NotFound();
            }

            return Results.Ok(professor);
        }

        [Topic(pubsubName:"servicebus-pubsub",name:"topico-equipe-2-professor")] 
        [HttpPost("/event")]
        public async Task<IResult> UpdateClient(Professor professor){      
            if(professor == null){
                return Results.BadRequest();
            }
            Console.WriteLine("EVENT " + professor.nomeDoProfessor);
            await _service.updateEventAsync(professor);

            return Results.Ok(professor);
        }
    }
}