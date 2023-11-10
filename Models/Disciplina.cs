namespace TAPR_Disciplina.Models {
    public class Disciplina {

        public Guid idDisciplina { get; set; }  
        public string nomeDisciplina { get; set; }
        public string cargaHoraria { get; set; }
        public string diaAula { get; set; }
        public Professor professor { get; set; }
        public Curso curso { get; set; }

    }
}
