
class Program
{
    // Config
    static Random random = new Random(353230932);


    static void Main()
    {
        // Doet zooi.
        
        RoadNetwork network= new RoadNetwork(5, 4, random);
        network.Print();
    }
}


