using System.Diagnostics;

namespace DaceloApi.Handlers;

public static class UptimeHandler
{
    public static Stopwatch stopwatch = new Stopwatch();

    public static void StartTimer()
    {
        UptimeHandler.stopwatch.Start();
    }
}