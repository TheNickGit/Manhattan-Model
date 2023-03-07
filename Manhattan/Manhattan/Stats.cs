
internal class Stats
{
    public static List<StatsCarEntry> carStats = new List<StatsCarEntry>();

    public void CreateCarStats(int ID, int travelTime, int distance)
    {
        StatsCarEntry entry = new StatsCarEntry(ID, travelTime, distance);
        carStats.Add(entry);
    }

    public void Print()
    {
        foreach(StatsCarEntry entry in carStats)
        {
            entry.Print();
        }
    }
}

