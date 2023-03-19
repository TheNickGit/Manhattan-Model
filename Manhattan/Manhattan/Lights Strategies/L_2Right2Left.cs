class L_2Right2Left
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;

    public L_2Right2Left(Dictionary<LinkedList<Car>, bool> incomingMap,
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
        this.inEtoW = inEtoW;
        this.inEtoS = inEtoS;
        this.inStoN = inStoN;
        this.inStoE = inStoE;
        this.inStoW = inStoW;
        this.inWtoN = inWtoN;
        this.inWtoE = inWtoE;
        this.inWtoS = inWtoS;
    }

    /// <summary>
    /// Changes the traffic lights, opting to let 3 directions go to the right and 1 to the left.
    /// </summary>
    public void Perform(Route.direction direction)
    {
        Program.stats.statsCrossing.count2R2L++;

        foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            incomingMap[entry.Key] = false;
        if (direction == Route.direction.N || direction == Route.direction.S)
        {
            incomingMap[inNtoE] = true;
            incomingMap[inEtoN] = true;
            incomingMap[inStoW] = true;
            incomingMap[inWtoS] = true;
        }
        else if (direction == Route.direction.E || direction == Route.direction.W)
        {
            incomingMap[inWtoN] = true;
            incomingMap[inNtoW] = true;
            incomingMap[inStoE] = true;
            incomingMap[inEtoS] = true;
        }
    }

    public (int traffic, Route.direction bestDir) Calculate()
    {
        int traffic = 0;
        Route.direction bestDir = Route.direction.None;
        int scoreNS = inNtoE.Count + inEtoN.Count + inStoW.Count + inWtoS.Count;
        int scoreEW = inWtoN.Count + inNtoW.Count + inStoE.Count + inEtoS.Count;

        if (scoreNS > 0)
        {
            bestDir = Route.direction.N;
            traffic = scoreNS;
        }
        if (scoreEW > scoreNS)
        {
            bestDir = Route.direction.E;
            traffic = scoreEW;
        }

        return (traffic, bestDir);
    }
}
