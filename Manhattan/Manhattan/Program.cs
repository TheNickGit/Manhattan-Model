
class Program
{
    // Config
    public static Random random = new Random(353230932);
    public static int numberOfCars = 20;
    public static int xLength = 3;
    public static int yLength = 3;
    static int networkAmount = 4;
    public static lightsTactic lightsMode = lightsTactic.hardcode1D;
    public static int lightInterval = 5;
    static bool printMode = true;

    // Property
    static RoadNetwork network;
    static Stats[] statsList = new Stats[networkAmount];
    public static Stats stats;
    public static bool finished;
    public static int iteration = 0;
    static int networkIteration = 0;
    public static List<Car> cars = new List<Car>();
    public enum lightsTactic { adaptive, hardcode1D }


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
            Console.WriteLine(iteration);
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
        iteration++;
        Iteration();
    }

    static void FinishNetwork()
    {
        finished = false;
        iteration = 0;
        networkIteration++;

        if (networkIteration < networkAmount)
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
        for(int i = 0; i < networkAmount;i++)
        {
             statsList[i].Print();
        }


        Console.WriteLine("HELEMAAL KLAAR!");
        System.Environment.Exit(0);
        
    }
}
