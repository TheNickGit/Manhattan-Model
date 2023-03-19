using System.Diagnostics.Metrics;

class L_AllRight
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    public LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;

    public L_AllRight(Dictionary<LinkedList<Car>, bool> incomingMap,
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
    /// Changes the traffic lights.
    /// </summary>
    public void Perform()
    {
        Program.stats.statsCrossing.count4R++;

        foreach (KeyValuePair<LinkedList<Car>, bool> entry in incomingMap)
            incomingMap[entry.Key] = false;
        incomingMap[inNtoW] = true;
        incomingMap[inWtoS] = true;
        incomingMap[inStoE] = true;
        incomingMap[inEtoN] = true;
    }

    public (int traffic, Route.direction bestDir) Calculate()
    {
        int traffic = inNtoW.Count + inWtoS.Count + inStoE.Count + inEtoN.Count;
        Route.direction bestDir = Route.direction.None;

        return (traffic, bestDir);
    }
}
