using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class RobotReader : IReader
{
    private readonly string DEFAULT_FILE_PATH = Application.persistentDataPath;

    private const string FILE_TYPE = ".json";

    public string Read(string filename)
    {
        string result = string.Empty;

        using (var fileStream = new FileStream(Path.Combine(DEFAULT_FILE_PATH, filename, FILE_TYPE), FileMode.Open))
        {
            using (var streamReader = new StreamReader(fileStream))
            {
                result = streamReader.ReadToEnd();
            }
        }

        return result;
    }

    public async Task<string> ReadAsync(string filename)
    {
        string result = string.Empty;
        
        using (var fileStream = new FileStream(Path.Combine(DEFAULT_FILE_PATH, filename, FILE_TYPE), FileMode.Open))
        {
            using (var streamReader = new StreamReader(fileStream))
            {
                result = await streamReader.ReadToEndAsync();
            }
        }

        return result;
    }
}
