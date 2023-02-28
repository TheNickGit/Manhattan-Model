

internal class RoadNetwork
{
    // Houd alle kruispunten bij (en wat meta data over hoeveelheid auto's?)

    Crossing[,] network;
    int xLength, yLength;
    List<Car> cars;

    public RoadNetwork(int x, int y, Random random)
    {
        network = new Crossing[x, y];
        xLength = x;
        yLength = y;
        for (int i = 0; i < yLength; i++)
            for (int j = 0; j < xLength; j++)
                network[j, i] = new Crossing(random);

    }

    public void Print()
    {
        for (int y = 0; y < yLength; y++)
        {
            //Console.Write("|");
            for (int x = 0; x < xLength; x++)
            {
                Console.Write("  [");
                network[x, y].Print(0);
                Console.Write("]  ");
            }
            Console.WriteLine("");
            //Console.Write("|");
            for (int x = 0; x < xLength; x++)
            {
                Console.Write(" [");
                network[x, y].Print(1);
                Console.Write("] ");
            }
            Console.WriteLine("");
            //Console.Write("|");
            for (int x = 0; x < xLength; x++)
            {
                Console.Write("  [");
                network[x, y].Print(2);
                Console.Write("]  ");
            }

            //Console.WriteLine("|" + "\n|");
            Console.WriteLine("\n");
        }
    }
}
