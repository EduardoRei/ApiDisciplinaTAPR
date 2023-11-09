namespace DisciplinaProfessorAPI.Models {
    public class Disciplina {

        public Guid id { get; set; }  
        public string nomeDisciplina { get; set; }
        public string horarioAula { get; set; }
        public string diaAula { get; set; }
        public Professor professor { get; set; }
        public Curso curso { get; set; }

    }
}
