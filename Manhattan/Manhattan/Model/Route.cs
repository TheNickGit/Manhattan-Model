
internal class Route
{
    public enum direction { None, N, E, S, W }

    public LinkedList<direction> route = new LinkedList<direction>();


    /// <summary>
    /// Add a direction to the route list.
    /// </summary>
    /// <param name="d"></param>
    public void Add(direction d)
    {
        route.AddLast(d);
    }

    /// <summary>
    /// Remove the first entry of the route list.
    /// </summary>
    public void Remove()
    {
        route.RemoveFirst();
    }

    public void Print()
    {
        string str = "<";
        foreach(direction d in route)
        {
            str += d.ToString() + ",";
        }
        str += ">";
        Console.WriteLine(str);
    }
}