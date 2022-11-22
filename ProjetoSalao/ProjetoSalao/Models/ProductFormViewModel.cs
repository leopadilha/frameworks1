namespace ProjetoSalao.Models
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Provider> Providers { get; set; }
    }
}
