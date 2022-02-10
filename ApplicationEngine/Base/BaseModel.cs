namespace ApplicationEngine.Base;

public abstract class BaseModel
{
    internal abstract void ApplicationStart();
    internal abstract void ApplicationTick();
    internal abstract void ApplicationLateTick();
    internal abstract void ApplicationDraw();
    internal abstract void ApplicationEnd();
}