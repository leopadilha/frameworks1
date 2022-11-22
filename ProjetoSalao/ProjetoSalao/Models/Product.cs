using System.ComponentModel.DataAnnotations;

namespace ProjetoSalao.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do produto")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Por favor informe o preço do produto")]
        public string Price { get; set; }
    }
}
