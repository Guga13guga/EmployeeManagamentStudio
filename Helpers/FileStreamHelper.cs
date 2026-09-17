namespace EmployeeManagamentStudio.Helpers;

public static class FileStreamHelper
{

    /// <summary>
    /// Writes the specified content to a file at the given file path. If the file does not exist, it will be created. The content is serialized to JSON format before writing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <param name="content"></param>
    /// <exception cref="IOException"></exception>
    public static void WriteContentToFile<T>(string filePath, T content)
    {
        try
        {
            var serializedContent = System.Text.Json.JsonSerializer.Serialize(content);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using var writer = new StreamWriter(filePath);
            writer.Write(serializedContent);
        }
        catch (Exception ex)
        {
            throw new IOException($"An error occurred while writing to the file at path {filePath}.", ex);
        }
    }

    /// <summary>
    /// Reads the content from a file at the specified file path and deserializes it into an object of type T. If the file does not exist, a new instance of T is returned. The content is expected to be in JSON format.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="IOException"></exception>
    public static T ReadContentFromFile<T>(string filePath) where T : new()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return new T();
            }

            using var reader = new StreamReader(filePath);
            var content = reader.ReadToEnd();
            return System.Text.Json.JsonSerializer.Deserialize<T>(content);
        }
        catch (Exception ex)
        {
            throw new IOException($"An error occurred while reading from the file at path {filePath}.", ex);
        }
    }
}
