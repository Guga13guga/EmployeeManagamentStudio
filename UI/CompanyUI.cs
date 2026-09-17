using EmployeeManagamentStudio.Consts;
using EmployeeManagamentStudio.Models;
using EmployeeManagamentStudio.Services;

namespace EmployeeManagamentStudio.UI;

public class CompanyUI
{
    private readonly CompanyService _company;
    private readonly DepartmentService _deparments;
    private readonly EmployeeService _employeeService;

    public CompanyUI()
    {
        _company = new CompanyService(FilePaths.CompaniesStoragePath);
        _deparments = new DepartmentService(FilePaths.DepartmentsStoragePath);
        _employeeService = new EmployeeService(FilePaths.EmployeesStoragePath);
    }

    public void RunCompanyUi()
    {
        while (true)
        {
            Console.WriteLine("Company Management");
            Console.WriteLine("1. Add Company");
            Console.WriteLine("2. List Companies");
            Console.WriteLine("3. Update Company");
            Console.WriteLine("4. Delete Company");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddCompany();
                    break;
                case "2":
                    ListCompanies();
                    break;
                case "3":
                    UpdateCompany();
                    break;
                case "4":
                    DeleteCompany();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            if (input == "5")
            {
                Console.Clear();
                break;
            }
        }
    }

    private void DeleteCompany()
    {
        Console.WriteLine("Delete Company");
        Console.WriteLine("Enter company ID to delete:");
        var id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Company ID cannot be empty.");
            return;
        }
        Console.WriteLine("are you sure you want to delete this company? (y/n), becouse we delete also related data:");
        var confirm = Console.ReadLine();
        if (string.IsNullOrEmpty(confirm) || (confirm != "y" && confirm != "Y"))
        {
            Console.WriteLine("Company deletion cancelled.");
            return;
        }

        var allDepartments = _deparments.GetAll().Where(d => d.CompanyId == int.Parse(id)).ToList();
        foreach (var department in allDepartments)
        {
            _employeeService.DeleteEmployeesByDepartmentId(department.Id);
        }

        _deparments.DeleteDepartmentsByCompanyId(int.Parse(id));
        _company.DeleteCompany(int.Parse(id));
    }

    private void UpdateCompany()
    {
        Console.WriteLine("Update Company");
        Console.WriteLine("Enter company ID to update:");
        var id = Console.ReadLine();
        if (string.IsNullOrEmpty(id))
        {
            Console.WriteLine("Company ID cannot be empty.");
            return;
        }
        Console.WriteLine("Enter new company name:");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Company name cannot be empty.");
            return;
        }
        Console.WriteLine("Enter new company phone number:");
        var phone = Console.ReadLine();
        Console.WriteLine("Enter new company address:");
        var address = Console.ReadLine();
        Console.WriteLine("Enter new company city:");
        var city = Console.ReadLine();
        Console.WriteLine("Enter new company country:");
        var country = Console.ReadLine();
        _company.UpdateCompany(new Company
        {
            Id = int.Parse(id),
            Name = name,
            Phone = phone,
            Address = address,
            City = city,
            Country = country
        });
    }

    private void ListCompanies()
    {
        Console.WriteLine("List Companies");
        foreach (var company in _company.GetAll())
        {
            Console.WriteLine($"Id: {company.Id}, Name: {company.Name}, Phone: {company.Phone}, Address: {company.Address}, City: {company.City}, Country: {company.Country}");
        }
    }

    private void AddCompany()
    {
        Console.WriteLine("Add Company");
        Console.WriteLine("Enter company name:");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Company name cannot be empty.");
            return;
        }
        Console.WriteLine("enter company phone number:");
        var phone = Console.ReadLine();
        Console.WriteLine("Enter company address:");
        var address = Console.ReadLine();
        Console.WriteLine("Enter company city:");
        var city = Console.ReadLine(); 
        Console.WriteLine("Enter company country:");
        var country = Console.ReadLine();
        _company.Add(new Company
        {
            Name = name,
            Phone = phone,
            Address = address,
            City = city,
            Country = country
        });
    }
}
