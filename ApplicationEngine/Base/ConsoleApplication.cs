using System.Runtime.CompilerServices;

namespace ApplicationEngine.Base;

public abstract class ConsoleApplication : Application
{
    public sealed override void Run()
    {
        IsRunning = true;

        Initialize();
        ApplicationStart();
        while (IsRunning)
        {
            ApplicationTick();
            ApplicationLateTick();
        }

        ApplicationEnd();
    }
}