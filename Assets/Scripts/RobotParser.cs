using UnityEngine;
using System;
using System.Threading.Tasks;

public class RobotParser
{
    private IReader robotReader;

    public RobotParser(IReader robotReader)
    {
        if (robotReader == null)
        {
            throw new ArgumentNullException(nameof(robotReader), "Robot reader reference cannot be null. Use RobotReader or create own.");
        }

        this.robotReader = robotReader;
    }

    public async Task<RobotModel> ParseRobot(IRobotParser parser, string data)
    {
        if (parser == null)
        {
            throw new ArgumentNullException(nameof(parser));
        }

        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        var result = await parser.Parse(data);
        return result;
    }
}
