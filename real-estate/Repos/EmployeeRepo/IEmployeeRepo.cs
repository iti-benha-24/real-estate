using real_estate.Models;

namespace real_estate.Repos.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();
        Employee GetByIdWithDetails(int id);
        void Add(Employee emp);
        Employee GetById(int id);
        void Edit(Employee emp);
        void Delete(Employee emp);
        void Save();
    }
}
