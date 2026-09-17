namespace EmployeeManagamentStudio.Helpers;

public static class FileStreamHelper
{
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

    public static T ReadContentFromFile<T>(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at path {filePath} does not exist.");
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
