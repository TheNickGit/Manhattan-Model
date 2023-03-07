﻿
class Program
{
    // Config
    public static Random random = new Random(353230932);
    public static int numberOfCars = 10000;
    public static int xLength = 10;
    public static int yLength = 10;
    static int networkAmount = 2;
    static bool printMode = false;


    // Property
    static RoadNetwork network;
    static Stats[] statsList = new Stats[networkAmount];
    public static Stats stats;
    public static bool finished;
    public static int iteration = 0;
    static int networkIteration = 0;
    public static List<Car> cars = new List<Car>();

    /// <summary>
    /// Main method.
    /// </summary>
    static void Main()
    {
        for (int i = 0; i < networkAmount; i++)
        {
            statsList[i] = new Stats();
        }
        stats = statsList[0];

        // Doet zooi.
        network = new RoadNetwork(xLength, yLength);
        Iteration();
    }

    /// <summary>
    /// Perform an iteration.
    /// </summary>
    static void Iteration()
    {
        
        if (printMode)
        {
            Console.Clear();
            Console.WriteLine(iteration++);
            network.Print();
            stats.Print();
        }

        // do updates
        network.Update();

        if (finished)
        {
            FinishNetwork();
        }

        if(printMode)
            Console.ReadLine();

        Iteration();
    }

    static void FinishNetwork()
    {
        finished = false;
        iteration = 0;
        networkIteration++;

        if (networkIteration < networkAmount - 1)
        {
            stats = statsList[networkIteration];
            network = new RoadNetwork(xLength, yLength);
        }
        else
            FinishProgram();
    }

    static void FinishProgram()
    {
        // TODO: Doe random statistiek zooi.

        Console.WriteLine("HELEMAAL KLAAR!");
        System.Environment.Exit(0);
        
    }
}
