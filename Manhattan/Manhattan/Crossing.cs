
internal class Crossing
{

    // functionaliteit van de stoplichten
    // Bewegen auto's 
    Random random;

    public LinkedList<Car> incN, incE, incS, incW;
    public Crossing neiN, neiE, neiS, neiW;

    public Crossing(Random random)
    {
        this.random = random;
        incN = new LinkedList<Car>();
        incE = new LinkedList<Car>();
        incS= new LinkedList<Car>();
        incW = new LinkedList<Car>();
    }

    public void AddCar(Car car, int xDist, int yDist)
    {
        // Exception: only moving N or S
        if (xDist == 0)
        {
            double randomNum = Program.random.NextDouble();

            if (randomNum <= 0.33)
                incW.AddLast(car);
            else if (randomNum <= 0.66)
                incE.AddLast(car);
            else
            {
                if (yDist > 0)
                    incN.AddLast(car);
                else
                    incS.AddLast(car);
            }
        }

        // Exception: only moving E or W
        if (yDist == 0)
        {
            double randomNum = Program.random.NextDouble();

            if (randomNum <= 0.33)
                incN.AddLast(car);
            else if (randomNum <= 0.66)
                incS.AddLast(car);
            else
            {
                if (xDist > 0)
                    incW.AddLast(car);
                else
                    incE.AddLast(car);
            }
        }
        
        // Normal: goes in two directions
        if (xDist > 0)
        {
            if (yDist > 0)
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                    incN.AddLast(car);
                else
                    incW.AddLast(car);
            }
            else
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                    incS.AddLast(car);
                else
                    incW.AddLast(car);
            }
        }
        else
        {
            if (yDist > 0)
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                    incN.AddLast(car);
                else
                    incE.AddLast(car);
            }
            else
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                    incS.AddLast(car);
                else
                    incE.AddLast(car);
            }
        }
    }

    public void Update()
    {
        if (incW.Count > 0)
        {
            Car car = incW.First();
            incW.RemoveFirst();

            if (neiE != null)
                car.outgoing = neiE.incW;
        }

        
    }

    /// <summary>
    /// Print (a part of) a crossing.
    /// </summary>
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
