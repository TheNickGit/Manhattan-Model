
internal class Crossing
{
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

    /// <summary>
    /// Add a car at a determined incoming list.
    /// </summary>
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

    /// <summary>
    /// Update the crossing.
    /// </summary>
    public void Update()
    {
        if (incN.Count > 0)
            UpdateInc(incN);
        if (incE.Count > 0)
            UpdateInc(incE);
        if (incS.Count > 0)
            UpdateInc(incS);
        if (incW.Count > 0)
            UpdateInc(incW);      
    }

    /// <summary>
    /// Update the incoming traffic lists.
    /// </summary>
    private void UpdateInc(LinkedList<Car> incList)
    {
        Car car = incList.First();
        incList.RemoveFirst();

        if (car.route.route.Count == 0)
            return;

        Route.direction dir = car.route.route.First();
        car.route.route.RemoveFirst();

        switch (dir)
        {
            case Route.direction.N:
                neiN.incS.AddLast(car);
                break;
            case Route.direction.E:
                neiE.incW.AddLast(car);
                break;
            case Route.direction.S:
                neiS.incN.AddLast(car);
                break;
            case Route.direction.W:
                neiW.incE.AddLast(car);
                break;
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
