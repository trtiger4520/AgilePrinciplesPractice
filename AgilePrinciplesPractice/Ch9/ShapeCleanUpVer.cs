namespace AgilePrinciplesPractice.Ch9.CleanUpVer;

public interface IShape
{
    void Draw();
}

public class Square : IShape
{
    public void Draw()
    {
    }
}

public class Circle : IShape
{
    public void Draw()
    {
    }
}

public class ShapeComparer : IComparer<IShape>
{
    private readonly static Dictionary<Type, int> priorities = new();

    static ShapeComparer()
    {
        priorities.Add(typeof(Circle), 1);
        priorities.Add(typeof(Square), 2);
    }

    public int Compare(IShape o1, IShape o2)
    {
        int priority1 = PriorityFor(o1.GetType());
        int priority2 = PriorityFor(o2.GetType());
        return priority1.CompareTo(priority2);
    }

    public static void DrawAllShapes(List<IShape> shapes)
    {
        shapes.Sort(new ShapeComparer());
        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }

    private static int PriorityFor(Type type)
    {
        if (priorities.TryGetValue(type, out int priority))
        {
            return priority;
        }

        return 0;
    }
}