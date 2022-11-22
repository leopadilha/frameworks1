using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ServiceRepository
{
    public interface IServiceRepository
    {
        List<Service> ListAll();

        Service Save(Service service);

        Service FindById(int id);
        Service Edit(Service service);

        void Remove(Service service);

    }
}
