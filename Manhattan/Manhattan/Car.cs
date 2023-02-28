
using System.Diagnostics;

internal class Car
{
    Crossing startlocation;
    Crossing destination;
    public Route route;

    public LinkedList<Car> outgoing;

    Stopwatch stopwatch = new Stopwatch();
    public long time;
    
    // Data voor tijd etc.
    

    public Car(int xDistance, int yDistance)
    {
        Program.cars.Add(this);
        CalculateRoute(xDistance, yDistance);

        stopwatch.Start();
        
    }

    /// <summary>
    /// Calculate the route of a car semi-randomly via the shortest path algorithm.
    /// </summary>
    private void CalculateRoute(int xDistance, int yDistance)
    {
        while (xDistance != 0 && yDistance != 0)
        {
            float chance = Math.Abs(xDistance/ (xDistance+yDistance));

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

    public void Finish()
    {
        stopwatch.Stop();
        time = stopwatch.ElapsedMilliseconds;
    } 


    // Houd route bij en wordt voortbewogen
}

