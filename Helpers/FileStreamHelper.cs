namespace EmployeeManagamentStudio.Helpers;

public static class FileStreamHelper
{
    /// <summary>
    /// Writes the specified content to a file at the given file path. If the file does not exist, it will be created.
    /// The content is serialized to JSON format before writing.
    /// </summary>
    public static void WriteContentToFile<T>(string filePath, T content)
    {
        try
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var serializedContent = System.Text.Json.JsonSerializer.Serialize(content);
            File.WriteAllText(filePath, serializedContent);
        }
        catch (Exception ex)
        {
            throw new IOException($"An error occurred while writing to the file at path {filePath}.", ex);
        }
    }

    /// <summary>
    /// Reads the content from a file at the specified file path and deserializes it into an object of type T.
    /// If the file does not exist, a new instance of T is returned.
    /// </summary>
    public static T ReadContentFromFile<T>(string filePath) where T : new()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return new T();
            }

            var content = File.ReadAllText(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<T>(content) ?? new T();
        }
        catch (Exception ex)
        {
            throw new IOException($"An error occurred while reading from the file at path {filePath}.", ex);
        }
    }
}
