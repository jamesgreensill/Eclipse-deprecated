using ApplicationEngine.Base;
using ApplicationEngine.Drivers;
using ApplicationEngine.Systems;

namespace ExampleApplication
{
    static class Example
    {
        static void Main()
        {
            ApplicationDriver.Create<ExampleApplication>();
            ApplicationDriver.Run();
        }
        class ExampleApplication : Application
        {
            protected override void OnApplicationStart()
            {
                // Code here will be executed when the application starts.
            }

            protected override void OnApplicationTick()
            {
                // Code here will be executed at the beginning of each frame.
            }

            protected override void OnApplicationLateTick()
            {
                // Code here will be executed at the end of each frame.
            }

            protected override void OnApplicationDraw()
            {
                // Code here will be executed when the application draws.
            }

            protected override void OnApplicationEnd()
            {
                // Code here will be executed when the application ends.
            }
        }
    }
}