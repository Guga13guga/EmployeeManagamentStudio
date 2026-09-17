using EmployeeManagamentStudio.Consts;
using EmployeeManagamentStudio.Models;
using EmployeeManagamentStudio.Services;

namespace EmployeeManagamentStudio.UI;

public class DepartmentUi
{
    private readonly DepartmentService _departmentService;
    private readonly CompanyService _companyService;
    private readonly EmployeeService _employeeService;

    public DepartmentUi()
    {
        _departmentService = new DepartmentService(FilePaths.DepartmentsStoragePath);
        _companyService = new CompanyService(FilePaths.CompaniesStoragePath);
        _employeeService = new EmployeeService(FilePaths.EmployeesStoragePath);
    }

    public void RunDepartamentUi()
    {
        while (true)
        {
            Console.WriteLine("Department Management");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. List Departments");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.WriteLine("5. List Employees in Department");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDepartment();
                    break;
                case "2":
                    ListDepartments();
                    break;
                case "3":
                    UpdateDepartment();
                    break;
                case "4":
                    DeleteDepartment();
                    break;
                case "5":
                    ShowEmployees();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (input == "6")
            {
                Console.Clear();
                break;
            }
        }
    }

    private void ShowEmployees()
    {
        Console.WriteLine("choice your department to view employees:");
        ListDepartments();
        Console.WriteLine("enter department id:");
        var input = Console.ReadLine();
        var departmentId = int.TryParse(input, out var id) ? id : -1;
        var department = _departmentService.GetAll().FirstOrDefault(d => d.Id == departmentId);
        if (department is null)
        {
            Console.WriteLine("Department not found.");
            return;
        }
        var employees = _employeeService.GetEmployeesByDepartmentId(departmentId);
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found in this department.");
            return;
        }

        foreach (var employee in employees)
        {
            Console.WriteLine($"- {employee.FirstName} {employee.LastName} ({employee.Email})");
        }
    }

    private void DeleteDepartment()
    {
        Console.WriteLine("choice your department to delete:");
        ListDepartments();
        Console.WriteLine("enter department id:");
        var input = Console.ReadLine();
        var departmentId = int.TryParse(input, out var id) ? id : -1;
        var department = _departmentService.GetAll().FirstOrDefault(d => d.Id == departmentId);
        if (department is null)
        {
            Console.WriteLine("Department not found.");
            return;
        }
        _employeeService.DeleteEmployeesByDepartmentId(departmentId);
        _departmentService.DeleteDepartment(departmentId);
    }

    private void UpdateDepartment()
    {
        Console.WriteLine("choice your department to update:");
        ListDepartments();
        Console.WriteLine("enter department id:");
        var input = Console.ReadLine();
        var departmentId = int.TryParse(input, out var id) ? id : -1;
        var department = _departmentService.GetAll().FirstOrDefault(d => d.Id == departmentId);
        if (department is null)
        {
            Console.WriteLine("Department not found.");
            return;
        }

        Console.WriteLine($"Current Name: {department.Name}");
        Console.WriteLine("enter new department name (leave blank to keep current):");
        var newName = Console.ReadLine();
        if(!string.IsNullOrEmpty(newName))
        {
            department.Name = newName;
        }
        else
        {
            Console.WriteLine("Department name cannot be empty.");
            return;
        }

        Console.WriteLine("also update the department's company (y/n)?");
        var updateCompany = Console.ReadLine();
        if (updateCompany?.ToLower() == "y")
        {
            Console.WriteLine("enter new company name:");
            var newCompany = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCompany))
            {
                var companyObj = _companyService.GetAll().FirstOrDefault(c => c.Name.Equals(newCompany, StringComparison.OrdinalIgnoreCase));
                if (companyObj is null)
                {
                    Console.WriteLine("Company not found. Please add the company first.");
                    return;
                }
                department.CompanyId = companyObj.Id;
            }
        }
    }

    private void ListDepartments()
    {
        var departments = _departmentService.GetAll();
        if (departments.Count == 0)
        {
            Console.WriteLine("No departments found.");
            return;
        }

        foreach (var department in departments)
        {
            var company = _companyService.GetAll().FirstOrDefault(c => c.Id == department.CompanyId);
            var companyName = company != null ? company.Name : "Unknown Company";
            Console.WriteLine($"Department ID: {department.Id}, Name: {department.Name}, Company: {companyName}");
        }
    }

    private void AddDepartment()
    {
        Console.WriteLine("Add Department");
        Console.WriteLine("enter department name:");
        var name = Console.ReadLine();

        if(string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Department name cannot be empty.");
            return;
        }

        Console.WriteLine("enter company name:");
        var company = Console.ReadLine();
        var companyObj = _companyService.GetAll().FirstOrDefault(c => c.Name.Equals(company, StringComparison.OrdinalIgnoreCase));
        if(companyObj is null)
        {
            Console.WriteLine("Company not found. Please add the company first.");
            return;
        }

        _departmentService.Add(new Deparment { Name = name, CompanyId = companyObj.Id });
    }
}
