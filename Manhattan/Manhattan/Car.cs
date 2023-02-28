
using System.Diagnostics;

internal class Car
{
    Crossing startlocation;
    Crossing destination;
    Route route;
    Stopwatch stopwatch = new Stopwatch();
    public long time;
    
    // Data voor tijd etc.
    

    public Car()
    {
        
        stopwatch.Start();
    }

    public void Finish()
    {
        stopwatch.Stop();
        time = stopwatch.ElapsedMilliseconds;
    } 


    // Houd route bij en wordt voortbewogen
}

