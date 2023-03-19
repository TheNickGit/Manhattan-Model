class L_3Right1Left
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;

    public L_3Right1Left(Dictionary<LinkedList<Car>, bool> incomingMap,
        LinkedList<Car> inNtoE, LinkedList<Car> inNtoS, LinkedList<Car> inNtoW,
        LinkedList<Car> inEtoN, LinkedList<Car> inEtoW, LinkedList<Car> inEtoS,
        LinkedList<Car> inStoN, LinkedList<Car> inStoW, LinkedList<Car> inStoE,
        LinkedList<Car> inWtoN, LinkedList<Car> inWtoE, LinkedList<Car> inWtoS)
    {
        this.incomingMap = incomingMap;
        this.inNtoE = inNtoE;
        this.inNtoS = inNtoS;
        this.inNtoW = inNtoW;
        this.inEtoN = inEtoN;
        this.inEtoW= inEtoW;
        this.inEtoS = inEtoS;
        this.inStoN = inStoN;
        this.inStoE = inStoE;
        this.inStoW = inStoW;
        this.inWtoN= inWtoN;
        this.inWtoE = inWtoE;
        this.inWtoS = inWtoS;
    }

    /// <summary>
    /// Changes the traffic lights, opting to let 3 directions go to the right and 1 to the left.
    /// </summary>
    public void Perform(Route.direction direction)
    {
        foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            incomingMap[entry.Key] = false;
        if (direction == Route.direction.N)
        {
            incomingMap[inNtoW] = true;
            incomingMap[inNtoE] = true;
            incomingMap[inWtoS] = true;
            incomingMap[inEtoN] = true;
        }
        else if (direction == Route.direction.E)
        {
            incomingMap[inEtoN] = true;
            incomingMap[inEtoS] = true;
            incomingMap[inStoE] = true;
            incomingMap[inNtoW] = true;
        }
        else if (direction == Route.direction.S)
        {
            incomingMap[inStoW] = true;
            incomingMap[inStoE] = true;
            incomingMap[inWtoS] = true;
            incomingMap[inEtoN] = true;
        }
        else if (direction == Route.direction.W)
        {
            incomingMap[inWtoN] = true;
            incomingMap[inWtoS] = true;
            incomingMap[inStoE] = true;
            incomingMap[inNtoW] = true;
        }
    }

    public (int traffic, Route.direction bestDir) Calculate()
    {
        int traffic = 0;
        Route.direction bestDir = Route.direction.None;
        int scoreN = inNtoW.Count + inNtoE.Count + inWtoS.Count + inEtoN.Count;
        int scoreE = inEtoN.Count + inEtoS.Count + inStoE.Count + inNtoW.Count;
        int scoreS = inStoW.Count + inStoE.Count + inWtoS.Count + inEtoN.Count;
        int scoreW = inWtoN.Count + inWtoS.Count + inStoE.Count + inNtoW.Count;

        if (scoreN > 0)
        {
            bestDir = Route.direction.N;
            traffic = scoreN;
        }
        if (scoreE > scoreN)
        {
            bestDir = Route.direction.E;
            traffic = scoreE;
        }
        if (scoreS > scoreE)
        {
            bestDir = Route.direction.S;
            traffic = scoreS;
        }
        if (scoreW > scoreS)
        {
            bestDir = Route.direction.W;
            traffic = scoreW;
        }

        return (traffic, bestDir);
    }
}
