using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSalao.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public Client Client { get; set; }

        public int ClientId { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Por favor selecione uma data")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Por favor informe a hora do agendamento")]
        public string Hour { get; set; }

        public Scheduling() { }
    }
}
