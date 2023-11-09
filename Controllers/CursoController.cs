using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAPR_Curso.Services;
using TAPR_Disciplina.Models;

namespace TAPR_Curso.Controllers
{
    [ApiController]
    [Route("/api/v1[controller]")]
    public class CursoController : ControllerBase
    {
        private ICursoService _service;

        public CursoController(ICursoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> Get() {
            var listaCursos = await _service.GetAllAsync();

            return Results.Ok(listaCursos);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById(String id) {
            var listaCursos = await _service.GetByIdAsync(id);
            if (listaCursos == null) {
                return Results.NotFound();
            }
            return Results.Ok(listaCursos);
        }

        [HttpPost()]
        public async Task<IResult> InsertNew(Curso curso) {
            if (curso == null) {
                return Results.BadRequest();
            }
            await _service.saveNewAsync(curso);

            return Results.Ok(curso);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(string id, Curso curso) {
            if (curso == null || id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            curso = await _service.updateAsync(id, curso);

            if (curso == null) {
                return Results.NotFound();
            }

            return Results.Ok(curso);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(string id) {
            if (id.Equals(String.Empty)) {
                return Results.BadRequest();
            }

            var curso = await _service.DeleteAsync(id);

            if (curso == null) {
                return Results.NotFound();
            }

            return Results.Ok(curso);
        }
    }
}