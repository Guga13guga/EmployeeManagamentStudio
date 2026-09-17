using EmployeeManagamentStudio.Helpers;

namespace EmployeeManagamentStudio.Services;

public class GenericService<T> where T : class
{
    protected readonly List<T> _items;
    private readonly string _filePath;

    public GenericService(string filePath)
    {
        _items = new List<T>();
        _filePath = filePath;
        try
        {
            var existingItems = FileStreamHelper.ReadContentFromFile<List<T>>(_filePath);
            if (existingItems != null)
            {
                _items.AddRange(existingItems);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error occurred while reading from file.");
        }
    }

    public void Add(T item)
    {
        _items.Add(item);
        FileStreamHelper.WriteContentToFile(_filePath, _items);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        FileStreamHelper.WriteContentToFile(_filePath, _items);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public void SaveChanges()
    {
        FileStreamHelper.WriteContentToFile(_filePath, _items);
    }
}
