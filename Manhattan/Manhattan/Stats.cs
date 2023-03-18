
using System.IO;

internal class Stats
{
    public static List<StatsCarEntry> carStats = new List<StatsCarEntry>();
    public static string path = @".\test.txt";


    public void CreateCarStats(int ID, int travelTime, int distance)
    {
        StatsCarEntry entry = new StatsCarEntry(ID, travelTime, distance);
        carStats.Add(entry);
    }

    public void Print()
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (StatsCarEntry entry in carStats)
            {
                if (entry.ID >= 200)
                {
                }
                else
                {
                    writer.WriteLine("car ID: " + entry.ID + " | travel time: " + entry.travelTime + " | distance: " + entry.distance);
                }
            }
        }
       
    }
}