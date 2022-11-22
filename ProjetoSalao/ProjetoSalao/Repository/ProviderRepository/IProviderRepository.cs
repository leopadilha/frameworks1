using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ProviderRepository
{
    public interface IProviderRepository
    {
        List<Provider> ListAll();

        Provider Save(Provider provider);

        Provider FindById(int id);
        Provider Edit(Provider provider);

        void Remove(Provider provider);

    }
}
