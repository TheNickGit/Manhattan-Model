
using System.Diagnostics;

internal class Car
{
    int ID;
    public Route route = new Route();
    int routeLength = 0;

    public Car(int carID, int xDistance, int yDistance)
    {
        ID = carID;
        Program.cars.Add(this);
        routeLength = Math.Abs(xDistance) + Math.Abs(yDistance);
        CalculateRoute(xDistance, yDistance);
    }

    /// <summary>
    /// Calculate the route of a car semi-randomly via the shortest path algorithm.
    /// </summary>
    private void CalculateRoute(int xDistance, int yDistance)
    {
        while (xDistance != 0 || yDistance != 0)
        {
            float chance = (float)Math.Abs(xDistance)/ (float)(Math.Abs(xDistance) + Math.Abs(yDistance));

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
        route.Add(Route.direction.None);
    }

    /// <summary>
    /// Update car.
    /// </summary>
    public void Update()
    {
        // Delete car from sim and broadcast stats.
        if (route.route.Count <= 0)
        {
            RoadNetwork.carsToRemove.Add(this);
            EmitStat();
        }

    }

    public void Print()
    {
        route.Print();
    }

    public void EmitStat()
    {
        Program.stats.CreateCarStats(ID, Program.iteration, routeLength);
    }
}

