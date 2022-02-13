using System.ComponentModel;
using Raylib_cs;

namespace ApplicationEngine.Drivers.GraphicsDriver;

public class RaylibDriver : GraphicsDriver
{
    public override void InitializeWindow(int width, int height, string title) =>
        Raylib.InitWindow(width, height, title);

    public override void TerminateWindow() => Raylib.CloseWindow();

    public override void BeginDrawing() => Raylib.BeginDrawing();

    public override void EndDrawing() => Raylib.EndDrawing();

    public override void ClearBackground(EColor color) =>
        Raylib.ClearBackground(new Color(color.R, color.G, color.B, color.A));

    public override void SetWindowSize(int width, int height) => Raylib.SetWindowSize(width, height);

    public override void SetWindowTitle(string title) => Raylib.SetWindowTitle(title);

    public override void SetWindowPosition(int x, int y) => Raylib.SetWindowPosition(x, y);

    public override void SetWindowIcon(string path) => Raylib.SetWindowIcon(Raylib.LoadImage(path));

    public override void ToggleFullscreen() => Raylib.ToggleFullscreen();

    public override void MaximizeWindow() => Raylib.MaximizeWindow();

    public override void MinimizeWindow() => Raylib.MinimizeWindow();

    public override void HideCursor() => Raylib.HideCursor();

    public override void ShowCursor() => Raylib.ShowCursor();
}