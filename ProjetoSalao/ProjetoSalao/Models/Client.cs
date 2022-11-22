using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSalao.Models
{
    public class Client
    {
		public int Id { get; set; }

        [Required(ErrorMessage ="Por favor informe o nome do cliente")]
		[StringLength(100)]
		public string Name { get; set; }

		[Required(ErrorMessage ="Por favor informe o CPF do cliente")]
		[StringLength(15, ErrorMessage = "Por favor informe um cpf valido", MinimumLength = 14)]
		public string Cpf { get; set; }

		[Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		[Required(ErrorMessage = "Por favor selecione uma data")]
	
		public DateTime Birthdate { get; set; }

		[Required(ErrorMessage = "Por favor informe o telefone do cliente")]
		[Phone(ErrorMessage = "Por favor digite um telefone valido")]
		public string Telephone { get; set; }
		[Required(ErrorMessage ="Por favor informe o endereço do cliente")]
		
		public string Adress { get; set; }
		[Required(ErrorMessage ="Por favor informe o cep do cliente")]

		public string Zipcode { get; set; }
		[Required(ErrorMessage = "Por favor informe o complemento")]

		public string Complement { get; set; }
	}
}
