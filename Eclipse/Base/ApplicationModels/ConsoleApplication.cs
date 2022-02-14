using System.Runtime.InteropServices;
using ApplicationEngine.Base.Abstract;

namespace ApplicationEngine.Base.ApplicationModels;

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