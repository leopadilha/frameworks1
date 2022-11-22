using ProjetoSalao.Data;
using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BancoContext _bancoContext;

        public ClientRepository(BancoContext BancoContext)
        {
            _bancoContext = BancoContext;
        }

        public List<Client> ListAll()
        {
           
           return _bancoContext.Client.ToList();
        }

        public Client Save(Client Client)
        {
            _bancoContext.Client.Add(Client);
            _bancoContext.SaveChanges();
            return Client;
        }

        public Client FindById(int id)
        {
            return _bancoContext.Client.FirstOrDefault(client => client.Id == id);
        }

        public bool FindByCpf(string cpf)
        {
            var existisCpf = _bancoContext.Client.FirstOrDefault(client => client.Cpf == cpf);
            return existisCpf != null;
        }

        public Client UpdateClient(Client client)
        {
            _bancoContext.Client.Update(client);
            _bancoContext.SaveChanges();
            return client;
        }
        public void Remove(Client client)
        {
            _bancoContext.Client.Remove(client);
            _bancoContext.SaveChanges();
        }

        public bool FindByCpfAndDifferentId(string cpf, int id)
        {
            var existisCpf = _bancoContext.Client.FirstOrDefault(client => client.Cpf == cpf && client.Id != id);
            return existisCpf != null;
        }


    }
}
