
class Program
{
    // Config
    public static Random random = new Random(353230932);
    public static int numberOfCars = 10;
    public static int xLength = 5;
    public static int yLength = 5;


    // Property
    static RoadNetwork network;
    public static Stats stats = new Stats();
    static bool finished;
    public static int iteration = 0;
    public static List<Car> cars = new List<Car>();

    /// <summary>
    /// Main method.
    /// </summary>
    static void Main()
    {
        // Doet zooi.
        network = new RoadNetwork(xLength, yLength);
        Iteration();
    }

    /// <summary>
    /// Perform an iteration.
    /// </summary>
    static void Iteration()
    {
        Console.Clear();
        Console.WriteLine(iteration++);
        network.Print();
        stats.Print();

        // do updates
        network.Update();




        Console.ReadLine();
        Iteration();
    }
}
