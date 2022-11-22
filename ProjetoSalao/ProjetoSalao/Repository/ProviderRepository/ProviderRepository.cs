using ProjetoSalao.Data;
using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ProviderRepository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly BancoContext _bancoContext;

        public ProviderRepository(BancoContext BancoContext)
        {
            _bancoContext = BancoContext;
        }

        public List<Provider> ListAll()
        {
            return _bancoContext.Provider.ToList();
        }

        public Provider Save(Provider provider)
        {
            _bancoContext.Provider.Add(provider);
            _bancoContext.SaveChanges();
            return provider;
        }

        public Provider FindById(int id)
        {
            return _bancoContext.Provider.FirstOrDefault(provider => provider.Id == id);
        }

        public Provider Edit(Provider provider)
        {
            
            _bancoContext.Provider.Update(provider);
            _bancoContext.SaveChanges();
            return provider;
        }
        public void Remove(Provider provider)
        {
            _bancoContext.Provider.Remove(provider);
            _bancoContext.SaveChanges();
        }
    }
}
