using real_estate.Models;

namespace real_estate.Repos.ContractRepo
{
    public interface IContractRepo
    {
        List<Contract> GetAll();
        Contract GetById(int id);
        void Add(Contract contract);
        void Edit(Contract contract);
        void Delete(Contract contract);
        void Save();
        List<Client> GetAllClients();

    }
}
