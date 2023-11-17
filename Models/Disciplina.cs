namespace TAPR_Disciplina.Models {
    public class Disciplina {

        public Guid idDisciplina { get; set; }  
        public string nomeDisciplina { get; set; }
        public string cargaHoraria { get; set; }
        public string diaAula { get; set; }
        public Professor professor { get; set; }
        public Curso curso { get; set; }


        public Disciplina()
        {
            
        }
        public Disciplina(Guid _idDisciplina, string _nomeDisciplina, string _cargaHoraria, string _diasAula, Professor _professor, Curso _curso){
            this.idDisciplina = _idDisciplina;
            this.nomeDisciplina = _nomeDisciplina;
            this.cargaHoraria = _cargaHoraria;
            this.diaAula = _diasAula;
            this.professor = _professor;
            this.curso = _curso;
        }

    }
}
