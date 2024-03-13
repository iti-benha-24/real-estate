using Microsoft.EntityFrameworkCore;
using real_estate.Models;



namespace real_estate.Repos.ContractRepo
{
    public class ContractRepo : IContractRepo
    {
        private readonly real_estateDB db;

        public ContractRepo(real_estateDB _db)
        {
            db = _db;
        }

        public List<Contract> GetAll()
        {
            return db.Contracts.Include(x => x.property).ThenInclude(x => x.propertyStatus).Include(x => x.employee).Include(x => x.client).ToList();

        }

        public Contract GetById(int id)
        {
            return db.Contracts.Include(x => x.property).ThenInclude(x => x.city).Include(c => c.employee).Include(x => x.employee).FirstOrDefault(x => x.Id == id);
        }

        public void Add(Contract contract)
        {
            db.Contracts.Add(contract);
        }

        public void Edit(Contract contract)
        {
            db.Contracts.Update(contract);
        }

        public void Delete(Contract contract)
        {
            db.Contracts.Remove(contract);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return db.Clients.ToList();
        }

       
    }
}
