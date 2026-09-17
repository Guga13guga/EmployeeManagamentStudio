using EmployeeManagamentStudio.Models;

namespace EmployeeManagamentStudio.Services;

public class CompanyService : GenericService<Company>
{
    public CompanyService(string filePath) : base(filePath)
    {
    }

    public List<Company> SortCompaniesByName()
    {
        var companies = _items.OrderBy(i => i.Name);
        return companies.ToList();
    }

    public List<Company> FillterCompanyByName(string name)
    {
        var companies = _items.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return companies.ToList();
    }

    public void DeleteCompany(int companyId)
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
        if (company != null)
        {
            company.Name = updatedCompany.Name;
            SaveChanges();
        }
    }
}
