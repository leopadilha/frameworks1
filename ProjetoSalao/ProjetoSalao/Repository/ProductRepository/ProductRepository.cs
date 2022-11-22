using Microsoft.EntityFrameworkCore;
using ProjetoSalao.Data;
using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private BancoContext _bancoContext;

        public ProductRepository(BancoContext BancoContext)
        {
            _bancoContext = BancoContext;
        }

        public List<Product> ListAll()
        {
            return _bancoContext.Product.Include(a => a.Provider).ToList();
        }

        public Product Save(Product product)
        {
            _bancoContext.Product.Add(product);
            _bancoContext.SaveChanges();
            return product;
        }

        public Product FindById(int id)
        {
            return _bancoContext.Product.Include(a => a.Provider).FirstOrDefault(client => client.Id == id);
        }

        public Product Edit(Product product)
        {
            //Client clientDb = FindById(client.Id);
            _bancoContext.Product.Update(product);
            _bancoContext.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            _bancoContext.Product.Remove(product);
            _bancoContext.SaveChanges();
        }
    }
}
