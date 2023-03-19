
using System.IO;

internal class Stats
{
    List<StatsCarEntry> carStats = new List<StatsCarEntry>();
    string pathCars = @".\statsCars.txt";
    string pathCrossings = @".\statsCrossings.txt";

    public StatsCrossing statsCrossing = new StatsCrossing();

    public void CreateCarStats(int ID, int travelTime, int distance)
    {
        StatsCarEntry entry = new StatsCarEntry(ID, travelTime, distance);
        carStats.Add(entry);
    }

    public void Print()
    {
        using (StreamWriter writer = new StreamWriter(pathCars, true))
            foreach (StatsCarEntry entry in carStats)
            {
                if (entry.ID < Program.sampleSize)
                    writer.WriteLine("car ID: " + entry.ID + " | travel time: " + entry.travelTime + " | distance: " + entry.distance);
            }
        using (StreamWriter writer = new StreamWriter(pathCrossings, true))
        {
            writer.WriteLine("its  | " + statsCrossing.iterations);
            writer.WriteLine("2R2L | " + statsCrossing.count2R2L);
            writer.WriteLine("3R1L | " + statsCrossing.count3R1L);
            writer.WriteLine("4R   | " + statsCrossing.count4R);
            writer.WriteLine("1D1R | " + statsCrossing.count1D1R);
            writer.WriteLine("SR   | " + statsCrossing.countSR);
        }
    }
}