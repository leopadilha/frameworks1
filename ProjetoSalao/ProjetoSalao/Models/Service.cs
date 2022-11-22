using System.ComponentModel.DataAnnotations;

namespace ProjetoSalao.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor informe o serviço")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Por favor o valor do serviço")]
        public string Price { get; set; }

        public Service() { }
    }
}
