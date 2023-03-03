
using System.Diagnostics;

internal class Car
{
    Crossing startlocation;
    Crossing destination;
    public Route route = new Route();

    public LinkedList<Car> outgoing;
    

    public Car(int xDistance, int yDistance)
    {
        Program.cars.Add(this);
        CalculateRoute(xDistance, yDistance);
        
    }

    /// <summary>
    /// Calculate the route of a car semi-randomly via the shortest path algorithm.
    /// </summary>
    private void CalculateRoute(int xDistance, int yDistance)
    {
        route.Add(Route.direction.None);
        while (xDistance != 0 && yDistance != 0)
        {
            float chance = (Math.Abs(xDistance)/ (Math.Abs(xDistance) + Math.Abs(yDistance)));

            if (Program.random.NextDouble() < chance)
            {
                if (xDistance > 0)
                {
                    route.Add(Route.direction.E);
                    xDistance --;
                }
                else if (xDistance < 0)
                {
                    route.Add(Route.direction.W);
                    xDistance ++;
                }
            }
            else
            {
                if (yDistance > 0)
                {
                    route.Add(Route.direction.S);
                    yDistance --;
                }
                else if (yDistance < 0)
                {
                    route.Add(Route.direction.N);
                    yDistance ++;
                }
            }
        }
    }

    /// <summary>
    /// Update car.
    /// </summary>
    public void Update()
    {
        if (outgoing != null)
        {
            outgoing.AddLast(this);
            outgoing = null;
        }
    }
}

