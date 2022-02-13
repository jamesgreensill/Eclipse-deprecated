using ApplicationEngine.Base;
using ApplicationEngine.Base.Abstract;
using ApplicationEngine.Base.ApplicationModels;
using ApplicationEngine.Base.ECS;
using ApplicationEngine.Drivers.GraphicsDriver;

namespace ApplicationEngine.Systems;

public static class ApplicationEngine
{
    public static Application Application { get; set; }

    public static void Create<T>() where T : Application, new() => Create<T>(ApplicationSettings.Default);

    public static void Create<T>(ApplicationSettings settings) where T : Application, new()
    {
        Application = new T();
        Application.SetSettings(settings);
    }


    public static void InitializeGraphics<T>() where T : GraphicsDriver, new()
    {
        if (Application == null)
            throw new Exception("Application not created");
        WindowApplication? window = Application as WindowApplication;
        if (window == null)
            throw new Exception("Application is not a window application");

        window.CreateGraphicsDriver<T>();
    }

    public static void Run() => Application.Run();
    public static void Stop() => Application.Stop();
}