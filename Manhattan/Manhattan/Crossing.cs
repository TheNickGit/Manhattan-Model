
internal class Crossing
{

    // functionaliteit van de stoplichten
    // Bewegen auto's 
    Random random;

    List<Car> incN, incE, incS, incW;

    public Crossing(Random random)
    {
        this.random = random;
        incN = new List<Car>();
        incE = new List<Car>();
        incS= new List<Car>();
        incW = new List<Car>();


        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < random.Next(10); j++)
            {
                if (i == 0)
                    incN.Add(new Car());
                if (i == 1)
                    incE.Add(new Car());
                if (i == 2)
                    incW.Add(new Car());
                if (i == 3)
                    incS.Add(new Car());
            }
        }
    }

    public void Print(int version)
    {
        switch (version)
        {
            case 0:
                Console.Write(incN.Count);
                break;
            case 1:
                Console.Write(incW.Count + ",");
                Console.Write(incE.Count);
                break;
            case 2:
                Console.Write(incS.Count);
                break;
        }
    }
}
