namespace ApplicationEngine.Base;

public abstract class BaseModel
{
    internal bool HasInitialized;
    internal bool HasStarted;
    internal virtual void ApplicationStart()
    {
        // Used for optional overrides.
    }

    internal virtual void ApplicationTick()
    {
        // Used for optional overrides.
    }

    internal virtual void ApplicationLateTick()
    {
        // Used for optional overrides.
    }

    internal virtual void ApplicationDraw()
    {
        // Used for optional overrides.
    }

    internal virtual void ApplicationEnd()
    {
        // Used for optional overrides.
    }

    internal virtual void ApplicationInitialize()
    {
        // Used for optional overrides.
    }
}