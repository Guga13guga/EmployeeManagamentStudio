using EmployeeManagamentStudio.Models;

namespace EmployeeManagamentStudio.Services;

/// <summary>
/// Service class for managing Company entities, providing methods for sorting, filtering, deleting, and updating companies.
/// </summary>
public class CompanyService : GenericService<Company>
{
    public CompanyService(string filePath) : base(filePath)
    {
    }

    public List<Company> SortCompaniesByName()
    {
        return _items.OrderBy(i => i.Name).ToList();
    }

    public List<Company> FillterCompanyByName(string name)
    {
        return _items.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void DeleteCompany(Guid companyId)
    {
        var company = _items.FirstOrDefault(c => c.Id == companyId);
        if (company != null)
        {
            _items.Remove(company);
            SaveChanges();
        }
    }

    public void UpdateCompany(Company updatedCompany)
    {
        var company = _items.FirstOrDefault(c => c.Id == updatedCompany.Id);
        if (company == null)
        {
            return;
        }

        company.Name = updatedCompany.Name;
        company.Address = updatedCompany.Address;
        company.City = updatedCompany.City;
        company.Country = updatedCompany.Country;
        company.Phone = updatedCompany.Phone;
        company.Deparments = updatedCompany.Deparments;

        SaveChanges();
    }
}
