
internal class Crossing
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
        inEtoN, inEtoW, inEtoS,
        inStoN, inStoW, inStoE,
        inWtoN, inWtoE, inWtoS;
    public Crossing neiN, neiE, neiS, neiW;
    public int trafficLightTime = 0;
    public Route.direction direction = Route.direction.W;

    public Crossing()
    {
        inNtoE = new LinkedList<Car>();
        inNtoS = new LinkedList<Car>();
        inNtoW = new LinkedList<Car>();
        inEtoN = new LinkedList<Car>();
        inEtoW = new LinkedList<Car>();
        inEtoS = new LinkedList<Car>();
        inStoN = new LinkedList<Car>();
        inStoW = new LinkedList<Car>();
        inStoE = new LinkedList<Car>();
        inWtoN = new LinkedList<Car>();
        inWtoE = new LinkedList<Car>();
        inWtoS = new LinkedList<Car>();

        incomingMap = new Dictionary<LinkedList<Car>, bool>
        {
            { inNtoS, false },
            { inNtoW, false },
            { inEtoN, false },
            { inEtoW, false },
            { inEtoS, false },
            { inNtoE, false },
            { inStoN, false },
            { inStoW, false },
            { inStoE, false },
            { inWtoN, false },
            { inWtoE, false },
            { inWtoS, false }
        };

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
            {
                if (car.route.route.First() == Route.direction.N)
                    inWtoN.AddLast(car);
                else
                    inWtoS.AddLast(car);
            }
                
            else if (randomNum <= 0.66)
            {
                if (car.route.route.First() == Route.direction.N)
                    inEtoN.AddLast(car);
                else
                    inEtoS.AddLast(car);
            }
            else
            {
                if (yDist > 0)
                    inNtoS.AddLast(car);
                else
                    inStoN.AddLast(car);
            }
        }

        // Exception: only moving E or W
        else if (yDist == 0)
        {
            double randomNum = Program.random.NextDouble();

            if (randomNum <= 0.33)
            {
                if (car.route.route.First() == Route.direction.E)
                    inNtoE.AddLast(car);
                else
                    inNtoW.AddLast(car);
            }
            else if (randomNum <= 0.66)
            {
                if (car.route.route.First() == Route.direction.E)
                    inStoE.AddLast(car);
                else
                    inStoW.AddLast(car);
            }
            else
            {
                if (xDist > 0)
                    inWtoE.AddLast(car);
                else
                    inEtoW.AddLast(car);
            }
        }
        
        // Normal: goes in two directions
        else if (xDist > 0)
        {
            if (yDist > 0)
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                {
                    if (car.route.route.First() == Route.direction.E)
                        inNtoE.AddLast(car);
                    else
                        inNtoS.AddLast(car);
                }
                else
                {
                    if (car.route.route.First() == Route.direction.E)
                        inWtoE.AddLast(car);
                    else
                        inWtoS.AddLast(car);
                }
            }
            else
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                {
                    if (car.route.route.First() == Route.direction.E)
                        inStoE.AddLast(car);
                    else
                        inStoN.AddLast(car);
                }
                else
                {
                    if (car.route.route.First() == Route.direction.E)
                        inWtoE.AddLast(car);
                    else
                        inWtoN.AddLast(car);
                }
            }
        }
        else
        {
            if (yDist > 0)
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                {
                    if (car.route.route.First() == Route.direction.W)
                        inNtoW.AddLast(car);
                    else
                        inNtoS.AddLast(car);
                }
                else
                {
                    if (car.route.route.First() == Route.direction.W)
                        inEtoW.AddLast(car);
                    else
                        inEtoS.AddLast(car);
                }
            }
            else
            {
                double randomNum = Program.random.NextDouble();
                if (randomNum < 0.5)
                {
                    if (car.route.route.First() == Route.direction.W)
                        inStoW.AddLast(car);
                    else
                        inStoN.AddLast(car);
                }
                else
                {
                    if (car.route.route.First() == Route.direction.W)
                        inEtoW.AddLast(car);
                    else
                        inEtoN.AddLast(car);
                }
            }
        }
    }

    /// <summary>
    /// Update the crossing.
    /// </summary>
    public void Update()
    {
        LightOnInterval();

        foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            if (entry.Value)
                UpdateInc(entry.Key);   
    }

    /// <summary>
    /// Update the incoming traffic lists.
    /// </summary>
    private void UpdateInc(LinkedList<Car> incList)
    {
        if (incList.Count == 0)
            return;

        Car car = incList.First();
        incList.RemoveFirst();

        if (car.route.route.Count <= 1)
        {
            car.route.route.Clear();
            return;
        }
            

        Route.direction dir1 = car.route.route.First();
        car.route.route.RemoveFirst();
        Route.direction dir2 = car.route.route.First();

        switch (dir1)
        {
            case Route.direction.N:
                if (dir2 == Route.direction.E || dir2 == Route.direction.None)
                    neiN.inStoE.AddLast(car);
                else if (dir2 == Route.direction.W)
                    neiN.inStoW.AddLast(car);
                else if (dir2 == Route.direction.N)
                    neiN.inStoN.AddLast(car);
                break;
            case Route.direction.E:
                if (dir2 == Route.direction.E || dir2 == Route.direction.None)
                    neiE.inWtoE.AddLast(car);
                else if (dir2 == Route.direction.N)
                    neiE.inWtoN.AddLast(car);
                else if (dir2 == Route.direction.S)
                    neiE.inWtoS.AddLast(car);
                break;
            case Route.direction.S:
                if (dir2 == Route.direction.E || dir2 == Route.direction.None)
                    neiS.inNtoE.AddLast(car);
                else if (dir2 == Route.direction.W)
                    neiS.inNtoW.AddLast(car);
                else if (dir2 == Route.direction.S)
                    neiS.inNtoS.AddLast(car);
                break;
            case Route.direction.W:
                if (dir2 == Route.direction.N || dir2 == Route.direction.None)
                    neiW.inEtoN.AddLast(car);
                else if (dir2 == Route.direction.W)
                    neiW.inEtoW.AddLast(car);
                else if (dir2 == Route.direction.S)
                    neiW.inEtoS.AddLast(car);
                break;
        }
    }

    /// <summary>
    /// Changes the traffic lights based on fixed time intervals.
    /// </summary>
    public void LightOnInterval()
    {
        if (trafficLightTime == 0)
        {
            trafficLightTime = 5;
            if (direction == Route.direction.N) direction = Route.direction.E;
            else if (direction == Route.direction.E) direction = Route.direction.S;
            else if (direction == Route.direction.S) direction = Route.direction.W;
            else if (direction == Route.direction.W) direction = Route.direction.N;

            int i = 0;
            foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            {
                if (i >= 0 && i < 3 && direction == Route.direction.N)
                    incomingMap[entry.Key] = true;
                else if (i >= 3 && i < 6 && direction == Route.direction.E)
                    incomingMap[entry.Key] = true;
                else if (i >= 6 && i < 9 && direction == Route.direction.S)
                    incomingMap[entry.Key] = true;
                else if (i >= 9 && i < 12 && direction == Route.direction.W)
                    incomingMap[entry.Key] = true;
                else
                    incomingMap[entry.Key] = false;
                i++;
            }
        }
        trafficLightTime--;
    }


    /// <summary>
    /// Print (a part of) a crossing.
    /// </summary>
    public void Print(int version)
    {
        int count;
        switch (version)
        {
            case 0:
                count = inNtoE.Count + inNtoW.Count + inNtoS.Count;
                Console.Write(count.ToString("D4"));
                break;
            case 1:
                count = inWtoE.Count + inWtoN.Count + inWtoS.Count;
                Console.Write(count.ToString("D4") + ", ");
                count = inEtoW.Count + inEtoN.Count + inEtoS.Count;
                Console.Write(count.ToString("D4"));
                break;
            case 2:
                count = inStoW.Count + inStoN.Count + inStoE.Count;
                Console.Write(count.ToString("D4"));
                break;
        }
    }
}
