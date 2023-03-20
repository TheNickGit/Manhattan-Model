internal class Lights
{
    public L_3Right1Left l_3Right1Left;
    public L_AllRight l_AllRight;
    public L_StraightAndRight l_StraightAndRight;
    public L_OneDirection1R l_OneDirection1R;
    public L_2Right2Left l_2Right2Left;

    public Lights(Dictionary<LinkedList<Car>, bool> incomingMap,
        LinkedList<Car> inNtoE, LinkedList<Car> inNtoS, LinkedList<Car> inNtoW,
        LinkedList<Car> inEtoN, LinkedList<Car> inEtoW, LinkedList<Car> inEtoS,
        LinkedList<Car> inStoN, LinkedList<Car> inStoW, LinkedList<Car> inStoE,
        LinkedList<Car> inWtoN, LinkedList<Car> inWtoE, LinkedList<Car> inWtoS)
    {
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

        l_2Right2Left = new L_2Right2Left(incomingMap, inNtoE, inNtoS, inNtoW,
            inEtoN, inEtoW, inEtoS,
            inStoN, inStoW, inStoE,
            inWtoN, inWtoE, inWtoS);
    }
}
