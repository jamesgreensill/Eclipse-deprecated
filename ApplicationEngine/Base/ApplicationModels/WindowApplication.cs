using ApplicationEngine.Base.Abstract;
using ApplicationEngine.Base.Data;
using ApplicationEngine.Drivers.GraphicsDriver;
using Raylib_cs;

namespace ApplicationEngine.Base.ApplicationModels;

public abstract class WindowApplication : Application
{
    private readonly Frozen<GraphicsDriver> m_GraphicsDriver = new Frozen<GraphicsDriver>("Graphics Driver");

    public GraphicsDriver GraphicsDriver
    {
        get => m_GraphicsDriver.Value;
        set => m_GraphicsDriver.Value = value;
    }
    public void CreateGraphicsDriver<T>() where T : GraphicsDriver, new() => GraphicsDriver = new T();
    protected abstract void OnApplicationDraw();
    public sealed override void Run()
    {
        IsRunning = true;
        ApplicationInitialize();

        GraphicsDriver.InitializeWindow(Settings.Width, Settings.Height, Settings.Title);

        ApplicationStart();
        while (IsRunning)
        {
            ApplicationTick();

            ApplicationLateTick();

            ApplicationDraw();
        }

        ApplicationEnd();
        GraphicsDriver.TerminateWindow();
    }

    /// <summary>
    /// Called at the start of rendering
    /// </summary>
    internal sealed override void ApplicationDraw()
    {
        GraphicsDriver.BeginDrawing();
        GraphicsDriver.ClearBackground(GraphicsDriver.BackgroundColor);

        OnApplicationDraw();
        Objects.ForEach(o => o.ApplicationDraw());

        GraphicsDriver.EndDrawing();
    }
}