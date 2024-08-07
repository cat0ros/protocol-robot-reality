using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RobotModel
{
    private string robotName;

    public string RobotName
    {
        get => string.Copy(robotName);
        set
        {
            if (string.IsNullOrEmpty(robotName))
            {

            }
        }
    }

    private List<LinkRobot> linksRobot;
    private Vector3 position;
    private Vector3 eulerRotation;
}

public class LinkRobot
{
    private string name;

    public string Name
    {
        get => string.Copy(name);
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            name = value;
        }
    }

    public TypeJoint Type { get; set; }

    private LinkRobot[] robotLinks;

    public IReadOnlyCollection<LinkRobot> RobotLinks
    {
        get => robotLinks;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            robotLinks = value.ToArray();
        }
    }

    public Vector3 Position { get; set; }

    public Vector3 Rotation { get; set; }

    private string modelName;

    public string ModelName
    {
        get => string.Copy(modelName);
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            modelName = value;
        }
    }
}

public enum TypeJoint
{
    Revolute,
    Prismatic,
    None
}

public class RobotLinkBuilder
{
    private LinkRobot robotLink;

    public RobotLinkBuilder()
    {
        robotLink = new LinkRobot();
    }

    public RobotLinkBuilder AddName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        robotLink.Name = name;
        return this;
    }

    public RobotLinkBuilder AddTransform(Vector3 position, Vector3 rotation)
    {
        robotLink.Position = position;
        robotLink.Rotation = rotation;

        return this;
    }

    public RobotLinkBuilder AddRobotLinks(LinkRobot[] linksRobot)
    {
        if (linksRobot == null)
        {
            throw new ArgumentNullException(nameof(linksRobot));
        }

        robotLink.RobotLinks = linksRobot;
        return this;
    }

    public RobotLinkBuilder AddModelName(string modelName)
    {
        if (string.IsNullOrEmpty(modelName))
        {
            throw new ArgumentNullException(nameof(modelName));
        }

        robotLink.ModelName = modelName;
        return this;
    }

    public RobotLinkBuilder AddTypeJoint(TypeJoint typeJoint)
    {
        robotLink.Type = typeJoint;
        return this;
    }
}