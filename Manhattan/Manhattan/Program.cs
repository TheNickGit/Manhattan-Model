
class Program
{
    // Config
    public static Random random = new Random(353230932);
    public static int numberOfCars = 100;
    public static int xLength = 3;
    public static int yLength = 3;


    // Property
    static RoadNetwork network;
    static bool finished;
    static int iteration = 0;
    public static List<Car> cars = new List<Car>();

    /// <summary>
    /// Main method.
    /// </summary>
    static void Main()
    {
        // Doet zooi.
        network = new RoadNetwork(xLength, yLength);
        Iteration();
        //network.Print();
    }

    /// <summary>
    /// Perform an iteration.
    /// </summary>
    static void Iteration()
    {
        Console.Clear();
        Console.WriteLine(iteration++);
        network.Print();

        // do updates
        network.Update();

        Console.ReadLine();
        Iteration();
    }
}
