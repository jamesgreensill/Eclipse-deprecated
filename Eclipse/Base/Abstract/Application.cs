using System.Numerics;
using ApplicationEngine.Drivers;
using ApplicationEngine.Systems;

namespace ApplicationEngine.Base.Abstract;

/// <summary>
/// This is the base class for all application types. Unless you are to create a custom application type, you shouldn't
/// inherit from this class.
/// </summary>
/*
Note you will need to implement your own Application Loop.
A typical loop will look like this:

1->Start
2->while(running)
3->    Tick
4->    LateTick
5->    Draw (if you are using a rendering engine)
6->End

*/
public abstract class Application : BaseModel
{
    protected List<BaseModel> Objects
    {
        get => ApplicationFactory.Objects;
    }

    protected bool IsRunning;

    protected ApplicationSettings Settings { get; set; }

    /// <summary>
    /// Base constructor for the application class.
    /// </summary>
    public void Stop() => IsRunning = false;

    public abstract void Run();
    protected abstract void OnApplicationInitialize();
    protected abstract void OnApplicationStart();
    protected abstract void OnApplicationTick();
    protected abstract void OnApplicationLateTick();
    protected abstract void OnApplicationEnd();

    public void SetSettings(ApplicationSettings settings) => Settings = settings;

    /// <summary>
    /// Called before the applications first frame. Use this instead of a constructor for BaseModel and Applications.
    /// </summary>
    protected void Initialize()
    {
        ApplicationFactory.CreateObject<TimeDriver>();

        if (!HasInitialized)
        {
            OnApplicationInitialize();
            if (Objects.Count > 0)
            {
                for (var index = 0; index < Objects.Count; index++)
                {
                    var OBJ = Objects[index];
                    OBJ.ApplicationInitialize();
                    OBJ.HasInitialized = true;
                }
            }
        }

        HasInitialized = true;
    }

    /// <summary>
    /// Called on the applications first frame.
    /// </summary>
    internal sealed override void ApplicationStart()
    {
        if (!HasStarted)
        {
            OnApplicationStart();
            if (Objects.Count > 0)
            {
                for (var index = 0; index < Objects.Count; index++)
                {
                    var OBJ = Objects[index];
                    OBJ.ApplicationTick();
                    OBJ.HasStarted = true;
                }
            }
        }

        HasStarted = true;
    }

    /// <summary>
    /// Called at the start of every application frame.
    /// </summary>
    internal sealed override void ApplicationTick()
    {
        OnApplicationTick();

        if (Objects.Count > 0)
        {
            for (var index = 0; index < Objects.Count; index++)
            {
                var OBJ = Objects[index];
                OBJ.ApplicationTick();
            }
        }
    }

    /// <summary>
    /// Called at the end of every application frame.
    /// </summary>
    internal sealed override void ApplicationLateTick()
    {
        OnApplicationLateTick();
        if (Objects.Count > 0)
        {
            for (var index = 0; index < Objects.Count; index++)
            {
                var OBJ = Objects[index];
                OBJ.ApplicationLateTick();
            }
        }
    }

    /// <summary>
    /// Called at the end of the applications run.
    /// </summary>
    internal sealed override void ApplicationEnd()
    {
        OnApplicationEnd();
        if (Objects.Count > 0)
        {
            for (var index = 0; index < Objects.Count; index++)
            {
                var OBJ = Objects[index];
                OBJ.ApplicationEnd();
            }
        }
    }
}

public struct ApplicationSettings
{
    public static ApplicationSettings Default = new()
    {
        Width = 1280,
        Height = 720,
        Title = "Application",
        Position = new Vector2(0, 0),
        Fullscreen = false,
        Resizable = true,
        Borderless = false,
        Visible = true,
        Minimized = false,
        Maximized = false,
        Focused = true,
        CursorVisible = true
    };

    public Vector2 Position { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public string Title { get; set; }

    public bool Fullscreen { get; set; }

    public bool Resizable { get; set; }

    public bool Borderless { get; set; }

    public bool Visible { get; set; }

    public bool Minimized { get; set; }

    public bool Maximized { get; set; }

    public bool Focused { get; set; }

    public bool CursorVisible { get; set; }
}