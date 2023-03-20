class L_OneDirection
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;

    public L_OneDirection(Dictionary<LinkedList<Car>, bool> incomingMap,
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
        Program.stats.statsCrossing.count1D++;

        foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            incomingMap[entry.Key] = false;
        if (direction == Route.direction.N)
        {
            incomingMap[inNtoW] = true;
            incomingMap[inNtoS] = true;
            incomingMap[inNtoE] = true;
        }
        else if (direction == Route.direction.E)
        {
            incomingMap[inEtoN] = true;
            incomingMap[inEtoS] = true;
            incomingMap[inEtoW] = true;
        }
        else if (direction == Route.direction.S)
        {
            incomingMap[inStoN] = true;
            incomingMap[inStoE] = true;
            incomingMap[inStoW] = true;
        }
        else if (direction == Route.direction.W)
        {
            incomingMap[inWtoN] = true;
            incomingMap[inWtoS] = true;
            incomingMap[inWtoE] = true;
        }
    }

    public (int traffic, Route.direction bestDir) Calculate()
    {
        int traffic = 0;
        Route.direction bestDir = Route.direction.None;
        int scoreN = inNtoW.Count + inNtoS.Count + inNtoE.Count;
        int scoreE = inEtoN.Count + inEtoS.Count + inEtoW.Count;
        int scoreS = inStoN.Count + inStoE.Count + inStoW.Count;
        int scoreW = inWtoN.Count + inWtoS.Count + inWtoE.Count;

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
