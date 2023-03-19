class L_StraightAndRight
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;
    public int counter = 0;
    public L_StraightAndRight(Dictionary<LinkedList<Car>, bool> incomingMap,
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
    /// Changes the traffic lights.
    /// </summary>
    public void Perform(Route.direction direction)
    {
        counter++;
        if (direction == Route.direction.N || direction == Route.direction.S)
        {
            foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
                incomingMap[entry.Key] = false;
            incomingMap[inNtoW] = true;
            incomingMap[inNtoS] = true;
            incomingMap[inStoN] = true;
            incomingMap[inStoE] = true;

        }
        else if (direction == Route.direction.E || direction == Route.direction.W)
        {
            foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
                incomingMap[entry.Key] = false;
            incomingMap[inEtoW] = true;
            incomingMap[inEtoN] = true;
            incomingMap[inWtoE] = true;
            incomingMap[inWtoS] = true;
        }
    }

    public (int traffic, Route.direction bestDir) Calculate()
    {
        int traffic = 0;
        Route.direction bestDir = Route.direction.None;
        int scoreNS = inNtoW.Count + inNtoS.Count + inStoN.Count + inStoE.Count;
        int scoreEW = inEtoW.Count + inEtoN.Count + inWtoE.Count + inWtoS.Count;

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
