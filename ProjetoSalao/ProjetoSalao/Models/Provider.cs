using System.ComponentModel.DataAnnotations;

namespace ProjetoSalao.Models
{
    public class Provider
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Por favor informe o nome do fornecedor")]
		[StringLength(100)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Por favor informe o CPF do cliente")]
		[StringLength(14, ErrorMessage = "Por favor informe um cpf valido", MinimumLength = 14)]
		public string Cpf { get; set; }

		[Required(ErrorMessage = "Por favor informe o telefone do cliente")]
		[Phone(ErrorMessage = "Por favor digite um telefone valido")]
		public string Contact { get; set; }

		[Required(ErrorMessage = "Por favor informe o endereço do cliente")]
		[StringLength(100, ErrorMessage = "Por favor informe um endereço valido")]
		public string Adress { get; set; }

		[Required(ErrorMessage = "Por favor informe o cep do cliente")]
		[StringLength(15, ErrorMessage = "Por favor informe um cep valido", MinimumLength = 8)]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "Por favor informe o complemento do cliente")]
		[StringLength(20)]
		public string Complement { get; set; }
	}
}
