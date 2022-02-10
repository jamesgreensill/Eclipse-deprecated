using Raylib_cs;

namespace ApplicationEngine.Base;

public abstract class WindowApplication : Application
{
    protected abstract void OnApplicationDraw();

    public sealed override void Run()
    {
        IsRunning = true;
        ApplicationInitialize();
        Raylib.InitWindow(1280, 720, "Application Engine ~ James Greensill.");
        ApplicationStart();
        while (IsRunning)
        {
            ApplicationTick();

            ApplicationLateTick();
            

            Raylib.BeginDrawing();
            ApplicationDraw();
            Raylib.EndDrawing();
        }

        ApplicationEnd();
        Raylib.CloseWindow();
    }


    /// <summary>
    /// Called at the start of rendering
    /// </summary>
    internal sealed override void ApplicationDraw()
    {
        Raylib.ClearBackground(Color.RAYWHITE);
        
        OnApplicationDraw();
        Objects.ForEach(o => o.ApplicationDraw());
    }
}