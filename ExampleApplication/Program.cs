using ApplicationEngine.Base;
using ApplicationEngine.Base.ApplicationModels;
using ApplicationEngine.Drivers;
using ApplicationEngine.Drivers.GraphicsDriver;
using ApplicationEngine.Systems;
using ImGuiNET;
using Raylib_cs;

namespace ExampleApplication
{
    static class Example
    {
        static void Main()
        {
            ApplicationEngine.Systems.ApplicationEngine.Create<ExampleApplication>();
            ApplicationEngine.Systems.ApplicationEngine.InitializeGraphics<RaylibDriver>();
            ApplicationEngine.Systems.ApplicationEngine.Run();
        }

        class ExampleApplication : WindowApplication
        {
            public static bool MenuOpen;

            protected override void OnApplicationInitialize()
            {
                MenuOpen = true;
            }

            protected override void OnApplicationStart()
            {
                ImGuiDriver.Instance.Load(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

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

            protected override void OnApplicationEnd()
            {
                // Code here will be executed when the application ends.
            }

            protected override void OnApplicationDraw()
            {
                ImGui.Begin("Application Info", ref MenuOpen, ImGuiWindowFlags.MenuBar);
                ImGui.BulletText($"FPS: {TimeDriver.Instance.FPS}");
                ImGui.BulletText($"Frame Time: {TimeDriver.Instance.DeltaTime}");
                ImGui.End();
            }
        }
    }
}