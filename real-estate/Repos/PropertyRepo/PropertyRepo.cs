using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Repos.PropertyRepo
{
    public class PropertyRepo:IPropertyRepo
    {
        real_estateDB CON;
        public PropertyRepo(real_estateDB _con)
        {
            CON = _con;
        }
        public IQueryable<Property> GetAll()
        {
            return CON.Properties.Include(p => p.city).Include(p => p.propertyStatus);
        }
        public Property GetById(int id)
        {
            return CON.Properties.FirstOrDefault(d => d.Id == id);
        }
        public void Add(Property property)
        {
            CON.Properties.Add(property);
        }
        public Property GetDetails(int id)
        {
            return CON.Properties.Include(p => p.employee).Include(p => p.city).Include(p => p.propertyStatus).Include(p => p.propertyType).FirstOrDefault(p => p.Id == id);
        }
        public void Update(Property property)
        {
            CON.Properties.Update(property);
        }
        public void Delete(int id)
        {
            Property property = GetById(id);
            CON.Properties.Remove(property);
        }
        public void SaveChanges()
        {
            CON.SaveChanges();
        }
        public List<SelectListItem> GetAllEmp()
        {
            return CON.Employees.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();
        }
        public List<SelectListItem> GetCities()
        {
            return CON.Cities.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();
        }
        public List<SelectListItem> GetPropertyStatus()
        {
            return CON.Status.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.status
            }).ToList();
        }
        public List<SelectListItem> GetPropertyType()
        {
            return CON.Types.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.type
            }).ToList();
        }
        // new
        public List<Property> GetPropertiesNotHaveContract()
        {
            return CON.Properties.Where(x => x.contract == null).ToList();
        }


        public List<Property> Filter(int cityId,int statusId,int typeId)
        {
            IQueryable<Property> query = CON.Properties.Include(x => x.city);

            if (cityId != 0)
                query = query.Where(x => x.cityId == cityId);
            if (statusId != 0)
                query = query.Where(x => x.PropertyStatusId == statusId);
            if (typeId != 0)
                query = query.Where(x => x.PropertyTypeId == typeId);

            return query.ToList();
           
        }
    }
}
