
internal class Route
{
    // Route berekenen gebaseerd op start en eind locatie (beetje random)

    public enum direction { N, E, S, W }

    LinkedList<direction> route = new LinkedList<direction>();

    public void Add(direction d)
    {
        route.AddLast(d);
    }

    public void Remove()
    {
        route.RemoveFirst();
    }
}