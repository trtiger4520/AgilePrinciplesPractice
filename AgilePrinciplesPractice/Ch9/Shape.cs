﻿using System.Collections;

namespace AgilePrinciplesPractice.Ch9;

public interface Shape
{
    void Draw();
}

public class Square : Shape
{
    public void Draw()
    {
    }
}

public class Circle : Shape
{
    public void Draw()
    {
    }
}

public class ShapeComparer : IComparer
{
    private static Hashtable priorities = new Hashtable();

    static ShapeComparer()
    {
        priorities.Add(typeof(Circle), 1);
        priorities.Add(typeof(Square), 2);
    }

    public int Compare(object o1, object o2)
    {
        int priority1 = PriorityFor(o1.GetType());
        int priority2 = PriorityFor(o2.GetType());
        return priority1.CompareTo(priority2);
    }

    public void DrawAllShapes(ArrayList shapes)
    {
        shapes.Sort(new ShapeComparer());
        foreach (Shape shape in shapes)
        {
            shape.Draw();
        }
    }

    private int PriorityFor(Type type)
    {
        if (priorities.Contains(type))
        {
            return (int)priorities[type];
        }

        return 0;
    }
}