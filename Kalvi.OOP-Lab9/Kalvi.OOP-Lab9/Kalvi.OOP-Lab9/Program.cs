using System;
using System.Collections;
using System.Collections.Generic;


interface ITrigonometricFigure
{
    double GetVolume(); 
}

abstract class TrigonometricFigure
{
    public abstract double GetVolume();
}

class Sphere : TrigonometricFigure, ITrigonometricFigure
{
    public double Radius { get; set; }

    public Sphere(double radius)
    {
        Radius = radius;
    }

    public override double GetVolume()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }
}

class Cube : TrigonometricFigure, ITrigonometricFigure
{
    public double Side { get; set; }

    public Cube(double side)
    {
        Side = side;
    }

    public override double GetVolume()
    {
        return Math.Pow(Side, 3);
    }
}

class Cone : TrigonometricFigure, ITrigonometricFigure
{
    public double Radius { get; set; }
    public double Height { get; set; }

    public Cone(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    public override double GetVolume()
    {
        return (1.0 / 3.0) * Math.PI * Math.Pow(Radius, 2) * Height;
    }
}

class Organization : IComparable<Organization>, IComparer<Organization>, IEnumerable<Organization>
{
    public string Name { get; set; }
    public int Employees { get; set; }
    public double SuccessRating { get; set; } 

    public Organization(string name, int employees, double successRating)
    {
        Name = name;
        Employees = employees;
        SuccessRating = successRating;
    }

    public int CompareTo(Organization other)
    {
        return Employees.CompareTo(other.Employees);
    }

    public int Compare(Organization x, Organization y)
    {
        if (x.Employees != y.Employees)
        {
            return x.Employees.CompareTo(y.Employees);
        }
        return x.SuccessRating.CompareTo(y.SuccessRating);
    }

    public IEnumerator<Organization> GetEnumerator()
    {
        var organizations = new List<Organization> { this };
        organizations.Sort((x, y) => y.SuccessRating.CompareTo(x.SuccessRating));
        return organizations.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return $"Name: {Name}, Employees: {Employees}, Success Rating: {SuccessRating}";
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Task 1: Trigonometric Figures");

        var sphere = new Sphere(5);
        Console.WriteLine($"Sphere Volume: {sphere.GetVolume():F2}");

        var cube = new Cube(4);
        Console.WriteLine($"Cube Volume: {cube.GetVolume():F2}");

        var cone = new Cone(3, 7);
        Console.WriteLine($"Cone Volume: {cone.GetVolume():F2}");

        
        Console.WriteLine("\nTask 2: Organization Management");

        var organizations = new List<Organization>
        {
            new Organization("Alpha", 150, 4.5),
            new Organization("Beta", 100, 4.8),
            new Organization("Gamma", 200, 4.3),
        };

        organizations.Sort();
        Console.WriteLine("\nOrganizations sorted by number of employees:");
        foreach (var org in organizations)
        {
            Console.WriteLine(org);
        }

        organizations.Sort((x, y) => x.Compare(x, y));
        Console.WriteLine("\nOrganizations sorted by employees and success rating:");
        foreach (var org in organizations)
        {
            Console.WriteLine(org);
        }

        Console.WriteLine("\nOrganizations sorted by success rating (using IEnumerable):");
        organizations.Sort((x, y) => y.SuccessRating.CompareTo(x.SuccessRating));
        foreach (var org in organizations)
        {
            Console.WriteLine(org);
        }
    }
}
