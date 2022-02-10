using ApplicationEngine.Base.ECS;
using ApplicationEngine.Systems;

namespace ApplicationEngine.Base;

public abstract class Application
{
    private List<BaseModel> Objects => ApplicationFactory.Objects;
    private bool m_IsRunning;


    /// <summary>
    /// Base constructor for the application class.
    /// </summary>
    protected Application()
    {
        m_IsRunning = false;
    }

    public void Run()
    {
        m_IsRunning = true;
        ApplicationStart();
        while (m_IsRunning)
        {
            ApplicationTick();

            ApplicationLateTick();

            ApplicationDraw();
        }

        ApplicationEnd();
    }

    public void Stop() => m_IsRunning = false;


    protected abstract void OnApplicationStart();
    protected abstract void OnApplicationTick();
    protected abstract void OnApplicationLateTick();
    protected abstract void OnApplicationDraw();
    protected abstract void OnApplicationEnd();

    /// <summary>
    /// Called on the applications first frame.
    /// </summary>
    private void ApplicationStart()
    {
        OnApplicationStart();
        Objects.ForEach(o => o.ApplicationStart());
    }

    /// <summary>
    /// Called at the start of every application frame.
    /// </summary>
    private void ApplicationTick()
    {
        OnApplicationTick();
        Objects.ForEach(o => o.ApplicationTick());
    }

    /// <summary>
    /// Called at the end of every application frame.
    /// </summary>
    private void ApplicationLateTick()
    {
        OnApplicationLateTick();
        Objects.ForEach(o => o.ApplicationLateTick());
    }

    /// <summary>
    /// Called at the start of rendering
    /// </summary>
    private void ApplicationDraw()
    {
        OnApplicationDraw();
        Objects.ForEach(o => o.ApplicationDraw());
    }

    /// <summary>
    /// Called at the end of the applications run.
    /// </summary>
    private void ApplicationEnd()
    {
        OnApplicationEnd();
        Objects.ForEach(o => o.ApplicationEnd());
    }
}