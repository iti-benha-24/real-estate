using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Repos.EmployeeRepo
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly real_estateDB db;

        public EmployeeRepo(real_estateDB _db)
        {
            db = _db;
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetByIdWithDetails(int id)
        {
            return db.Employees
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.city)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.propertyStatus)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.propertyType)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.contract)
                        .FirstOrDefault(emp => emp.Id == id);
        }
        public void Add(Employee emp)
        {
            db.Employees.Add(emp);
        }

        public Employee GetById(int id)
        {
            return db.Employees.SingleOrDefault(emp => emp.Id == id);
        }

        public void Edit(Employee emp)
        {
            db.Employees.Update(emp);
        }

        public void Delete(Employee emp)
        {
            db.Employees.Remove(emp);
        }

        public void Save()
        {
            db.SaveChanges();
        }



    }
}
