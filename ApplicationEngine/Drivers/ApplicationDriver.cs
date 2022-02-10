using ApplicationEngine.Base;
using ApplicationEngine.Systems;

namespace ApplicationEngine.Drivers;

public static class ApplicationDriver
{
    public static Application Application { get; set; }

    public static void Create<T>() where T : Application, new() => Application = new T();
    public static void Run() => Application.Run();
    public static void Stop() => Application.Stop();
}