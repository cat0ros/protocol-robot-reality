using System.Threading.Tasks;

public interface IReader
{
    string Read(string filename);
    Task<string> ReadAsync(string filename);
}