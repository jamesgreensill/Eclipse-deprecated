using ApplicationEngine.Base.ECS;
using ApplicationEngine.Drivers;
using ApplicationEngine.Systems;


namespace ApplicationEngine.Base;

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
    protected List<BaseModel> Objects => ApplicationFactory.Objects;
    protected bool IsRunning;

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


    /// <summary>
    /// Called before the applications first frame. Use this instead of a constructor for BaseModel and Applications.
    /// </summary>
    protected void Initialize()
    {
        ApplicationFactory.CreateObject<TimeDriver>();

        if (!HasInitialized)
        {
            OnApplicationInitialize();
            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].ApplicationInitialize();
                Objects[i].HasInitialized = true;
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

            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].ApplicationTick();
                Objects[i].HasStarted = true;
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

        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].ApplicationTick();
        }
    }

    /// <summary>
    /// Called at the end of every application frame.
    /// </summary>
    internal sealed override void ApplicationLateTick()
    {
        OnApplicationLateTick();
        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].ApplicationLateTick();
        }
    }

    /// <summary>
    /// Called at the end of the applications run.
    /// </summary>
    internal sealed override void ApplicationEnd()
    {
        OnApplicationEnd();
        for (int i = 0; i < Objects.Count; i++)
        {
            Objects[i].ApplicationEnd();
        }
    }
}