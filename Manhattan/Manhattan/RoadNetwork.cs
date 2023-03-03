

internal class RoadNetwork
{
    // Houd alle kruispunten bij (en wat meta data over hoeveelheid auto's?)

    Crossing[,] network;
    int xLength, yLength;
    List<Car> cars = Program.cars;

    public RoadNetwork(int xin, int yin)
    {
        network = new Crossing[xin, yin];
        xLength = xin;
        yLength = yin;
        for (int y = 0; y < yLength; y++)
            for (int x = 0; x < xLength; x++)
                network[x, y] = new Crossing();

        for (int y = 0; y < yLength; y++)
            for (int x = 0; x < xLength; x++)
            {
                if ( x != 0)
                    network[x,y].neiW = network[x-1,y];
                if (x != xLength - 1)
                    network[x, y].neiE = network[x + 1, y];
                if (y != 0)
                    network[x, y].neiN = network[x, y - 1];
                if (y != yLength - 1)
                    network[x, y].neiS = network[x, y + 1];
            }

        for (int i = 0; i < Program.numberOfCars; i++)
            CreateCar();
    }

    /// <summary>
    /// Generate a random car an put it in the road network.
    /// </summary>
    public void CreateCar()
    {
        int xCoor = Program.random.Next(xLength);
        int yCoor = Program.random.Next(yLength);
        int xDest = Program.random.Next(xLength);
        int yDest = Program.random.Next(yLength);

        if (xCoor == xDest && yCoor == yDest)
        {
            CreateCar();
            return;
        }

        int xDist = xDest - xCoor;
        int yDist = yDest - yCoor;
        Car car = new Car(xDist, yDist);
        network[xCoor, yCoor].AddCar(car, xDist, yDist);
    }

    /// <summary>
    /// Updates shit.
    /// </summary>
    public void Update()
    {
        for (int y = 0; y < yLength; y++)
            for (int x = 0; x < xLength; x++)
                network[x,y].Update();
        foreach (Car car in cars)
            car.Update();

    }

    /// <summary>
    /// Print the complete road network.
    /// </summary>
    public void Print()
    {
        for (int y = 0; y < yLength; y++)
        {
            //Console.Write("|");
            for (int x = 0; x < xLength; x++)
            {
                Console.Write("    [");
                network[x, y].Print(0);
                Console.Write("]    ");
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
                Console.Write("    [");
                network[x, y].Print(2);
                Console.Write("]    ");
            }

            //Console.WriteLine("|" + "\n|");
            Console.WriteLine("\n");
        }
    }
}
