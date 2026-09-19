namespace EmployeeManagamentStudio.Consts;

/// <summary>
/// Contains file paths used for storing data related to companies, departments, and employees.
/// </summary>
public static class FilePaths
{
    private static string GetDataPath(string fileName)
    {
        var dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
        return Path.Combine(dataDirectory, fileName);
    }

    public static string CompaniesStoragePath => GetDataPath("companies.json");
    public static string DepartmentsStoragePath => GetDataPath("departments.json");
    public static string EmployeesStoragePath => GetDataPath("employees.json");
}
