using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ProductRepository
{
    public interface IProductRepository
    {

        List<Product> ListAll();

        Product Save(Product product);

        Product FindById(int id);
        Product Edit(Product product);

        void Remove(Product product);

        
    }
}
