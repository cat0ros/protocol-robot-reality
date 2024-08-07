using System.Threading.Tasks;

public interface IRobotParser
{
    Task<RobotModel> Parse(string data);
}