
using System.Diagnostics;

internal class Car
{
    Crossing startlocation;
    Crossing destination;
    Route route;
    
    // Data voor tijd etc.
    long startTime = Stopwatch.GetTimestamp();

    TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
    


    // Houd route bij en wordt voortbewogen
}

