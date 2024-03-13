using Microsoft.AspNetCore.Mvc.Rendering;
using real_estate.Models;

namespace real_estate.Repos.PropertyRepo
{
    public interface IPropertyRepo
    {
        IQueryable<Property> GetAll();
        Property GetById(int id);
        void Add(Property property);
        Property GetDetails(int id);
        void Update(Property property);
        void Delete(int id);
        void SaveChanges();
        List<SelectListItem> GetAllEmp();
        List<SelectListItem> GetCities();
        List<SelectListItem> GetPropertyStatus();
        List<SelectListItem> GetPropertyType();
        List<Property> GetPropertiesNotHaveContract();

        List<Property> Filter(int cityId, int statusId, int typeId);


    }
}
