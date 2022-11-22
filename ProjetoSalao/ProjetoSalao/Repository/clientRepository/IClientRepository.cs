using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.ClientRepository
{
   
        public interface IClientRepository
        {
            Client Save(Client Cliente);
            List<Client> ListAll();
            Client FindById(int id);
            bool FindByCpf(string cpf);
            Client UpdateClient(Client client);
            void Remove(Client client);
            bool FindByCpfAndDifferentId(string cpf, int id);

    }
    }

