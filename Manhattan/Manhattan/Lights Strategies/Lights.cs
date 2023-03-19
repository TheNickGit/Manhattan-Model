internal class Lights
{
    private Dictionary<LinkedList<Car>, bool> incomingMap;
    LinkedList<Car> inNtoE, inNtoS, inNtoW,
    inEtoN, inEtoW, inEtoS,
    inStoN, inStoW, inStoE,
    inWtoN, inWtoE, inWtoS;

    public L_3Right1Left l_3Right1Left;
    public L_AllRight l_AllRight;
    public L_StraightAndRight l_StraightAndRight;
    public L_OneDirection1R l_OneDirection1R;

    public Lights(Dictionary<LinkedList<Car>, bool> incomingMap,
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

        l_3Right1Left = new L_3Right1Left(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);

        l_AllRight = new L_AllRight(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);

        l_StraightAndRight = new L_StraightAndRight(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);

        l_OneDirection1R = new L_OneDirection1R(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);
    }
}
