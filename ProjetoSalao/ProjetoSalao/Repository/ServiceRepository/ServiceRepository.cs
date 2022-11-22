using ProjetoSalao.Data;
using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private BancoContext _bancoContext;

        public ServiceRepository(BancoContext BancoContext)
        {
            _bancoContext = BancoContext;
        }

        public List<Service> ListAll()
        {
            return _bancoContext.Service.ToList();
        }

        public Service Save(Service service)
        {
            _bancoContext.Service.Add(service);
            _bancoContext.SaveChanges();
            return service;
        }

        public Service FindById(int id)
        {
            return _bancoContext.Service.FirstOrDefault(client => client.Id == id);
        }

        public Service Edit(Service service)
        {
            //Client clientDb = FindById(client.Id);
            _bancoContext.Service.Update(service);
            _bancoContext.SaveChanges();
            return service;
        }

        public void Remove(Service service)
        {
            _bancoContext.Service.Remove(service);
            _bancoContext.SaveChanges();
        }
    }
}
 