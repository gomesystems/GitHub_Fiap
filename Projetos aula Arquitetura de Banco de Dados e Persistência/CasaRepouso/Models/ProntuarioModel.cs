namespace CasaRepouso.Models
{
    public class ProntuarioModel
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public int CondicaoId { get; set; }
        public int VisitaId { get; set; }
        public int FuncionarioId { get; set; }

        public string DataCriacao { get; set; }
        public string DataAlteracao { get; set; }
        public string Usuario { get; set; }
    }
}
