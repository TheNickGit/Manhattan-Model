
internal class StatsCarEntry
{
    public int ID;
    public int travelTime;
    public int distance;

    public StatsCarEntry(int ID, int travelTime, int distance)
    {
        this.ID = ID;
        this.travelTime = travelTime;
        this.distance = distance;
    }

    public void Print()
    {
        Console.WriteLine("car ID: " + ID + " | travel time: " + travelTime + " | distance: " + distance);
    }
}

