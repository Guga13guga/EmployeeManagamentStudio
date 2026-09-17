using EmployeeManagamentStudio.UI;

/// <summary>
/// this is main entry point of the application, it provides a console-based user interface for managing employees, departments, and companies.
/// </summary>
/// 

var employeUi = new EmployeeUI();
var departmentUi = new DepartmentUi();
var companyUi = new CompanyUI();

while(true)
{
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Manage Employees");
    Console.WriteLine("2. Manage Departments");
    Console.WriteLine("3. Manage Companies");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option: ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            employeUi.RunEmployeeUi();
            Console.ResetColor();
            break;
        case "2":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            departmentUi.RunDepartamentUi();
            Console.ResetColor();
            break;
        case "3":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            companyUi.RunCompanyUi();
            Console.ResetColor();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Exiting... Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
