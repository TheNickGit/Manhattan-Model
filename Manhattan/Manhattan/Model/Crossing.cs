﻿internal class Crossing
{

    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
        inEtoN, inEtoW, inEtoS,
        inStoN, inStoW, inStoE,
        inWtoN, inWtoE, inWtoS;
    public Crossing neiN, neiE, neiS, neiW;
    public Lights lights;
    int trafficLightTime = 0;
    int delay = 0;
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
            { inNtoE, false },
            { inEtoN, false },
            { inEtoW, false },
            { inEtoS, false },
            { inStoN, false },
            { inStoW, false },
            { inStoE, false },
            { inWtoN, false },
            { inWtoE, false },
            { inWtoS, false }
        };

        lights = new Lights(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);
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
        delay--;

        if (trafficLightTime == 0 && delay < 0)
        {
            delay = Program.delay;
            foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
                incomingMap[entry.Key] = false;
        }

        if (delay <= 0)
        {
            trafficLightTime--;
            if (trafficLightTime < 0)
            {
                switch (Program.lightsMode)
                {
                    // CASE: ADAPTIVE
                    case Program.lightsTactic.adaptive:
                        (int, Route.direction) tuple2R2L = lights.l_2Right2Left.Calculate();
                        (int, Route.direction) tuple3R1L = lights.l_3Right1Left.Calculate();
                        (int, Route.direction) tuple4R = lights.l_AllRight.Calculate();
                        (int, Route.direction) tuple1D1R = lights.l_OneDirection1R.Calculate();
                        (int, Route.direction) tupleSR = lights.l_StraightAndRight.Calculate();

                        // Get the best.
                        List<(int, Route.direction)> tupleList = new List<(int, Route.direction)> { tuple2R2L, tuple3R1L, tuple4R, tuple1D1R, tupleSR };
                        (int, Route.direction) bestTuple = (0, Route.direction.None);
                        bestTuple = tupleList.Max();

                        trafficLightTime = bestTuple.Item1 / 3;
                        if (trafficLightTime < 10)
                            trafficLightTime = 10;
                        direction = bestTuple.Item2;

                        if (bestTuple.Equals(tuple2R2L))
                            lights.l_2Right2Left.Perform(direction);
                        else if (bestTuple.Equals(tuple3R1L))
                            lights.l_3Right1Left.Perform(direction);
                        else if (bestTuple.Equals(tuple4R))
                            lights.l_AllRight.Perform();
                        else if (bestTuple.Equals(tuple1D1R))
                            lights.l_OneDirection1R.Perform(direction);
                        else if (bestTuple.Equals(tupleSR))
                            lights.l_StraightAndRight.Perform(direction);

                            break;
                    // CASE: ADAPTIVE1D
                    case Program.lightsTactic.adaptive1D:
                        (int, Route.direction) tuple = lights.l_OneDirection1R.Calculate();

                        trafficLightTime = tuple.Item1 / 3;
                        if (trafficLightTime < 4)
                            trafficLightTime = 4;
                        direction = tuple.Item2;

                        lights.l_OneDirection1R.Perform(direction);
                        break;
                        // CASE ADAPTIVE TIMER NOT DIRECTION
                    case Program.lightsTactic.adaptive1Dcycle:
                        (int, Route.direction) tuplec = lights.l_OneDirection1R.Calculate();
                        trafficLightTime = tuplec.Item1 / 3;
                        if (trafficLightTime < 10)
                            trafficLightTime = 10;
                        if (direction == Route.direction.N) direction = Route.direction.E;
                        else if (direction == Route.direction.E) direction = Route.direction.S;
                        else if (direction == Route.direction.S) direction = Route.direction.W;
                        else if (direction == Route.direction.W) direction = Route.direction.N;

                        lights.l_OneDirection1R.Perform(direction);
                        break;
                    // CASE: HARDCODE
                    case Program.lightsTactic.hardcode1D:
                        trafficLightTime = Program.lightInterval;
                        if (direction == Route.direction.N) direction = Route.direction.E;
                        else if (direction == Route.direction.E) direction = Route.direction.S;
                        else if (direction == Route.direction.S) direction = Route.direction.W;
                        else if (direction == Route.direction.W) direction = Route.direction.N;

                        lights.l_OneDirection1R.Perform(direction);
                        break;
                }
            } 
        }

        // Update all lanes where the trafic light is set to true
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
