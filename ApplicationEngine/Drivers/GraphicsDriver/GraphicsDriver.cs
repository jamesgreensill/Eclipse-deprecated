namespace ApplicationEngine.Drivers.GraphicsDriver;

/// <summary>
/// In house color class.
/// ---
/// A pretty standard and simple color class.
/// </summary>
public struct EColor
{
    public byte R;
    public byte G;
    public byte B;
    public byte A;

    public EColor(byte r, byte g, byte b, byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public EColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
        A = 255;
    }

    public EColor(byte r, byte g, byte b, float a)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * 255);
    }

    public EColor(byte r, byte g, byte b, float a, float alpha)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * alpha);
    }

    public EColor(byte r, byte g, byte b, float a, float alpha, float alpha2)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * alpha * alpha2);
    }

    public EColor(byte r, byte g, byte b, float a, float alpha, float alpha2, float alpha3)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * alpha * alpha2 * alpha3);
    }

    public EColor(byte r, byte g, byte b, float a, float alpha, float alpha2, float alpha3, float alpha4)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * alpha * alpha2 * alpha3 * alpha4);
    }

    public EColor(byte r, byte g, byte b, float a, float alpha, float alpha2, float alpha3, float alpha4, float alpha5)
    {
        R = r;
        G = g;
        B = b;
        A = (byte)(a * alpha * alpha2 * alpha3 * alpha4 * alpha5);
    }
    // EColor
}

public abstract class GraphicsDriver
{
    /// <summary>
    /// When the screen is refreshed the screen is cleared and the background color is drawn.
    /// </summary>
    public EColor BackgroundColor { get; set; }


    public abstract void InitializeWindow(int width, int height, string title);

    public abstract void TerminateWindow();

    /// <summary>
    /// Begin drawing to the screen. (Call this before drawing anything to the screen)
    /// </summary>
    public abstract void BeginDrawing();

    /// <summary>
    /// End drawing to the screen. (Call this after drawing everything to the screen)
    /// </summary>
    public abstract void EndDrawing();

    /*
     *
     *  Create your own conversion when creating a graphics driver for your rendering engine.
     * 
     */
    /// <summary>
    /// Clears the screen to the background color.
    /// </summary>
    /// <param name="color">background color</param>
    public abstract void ClearBackground(EColor color);

    /// <summary>
    /// Sets the size of the screen.
    /// </summary>
    /// <param name="width">Input int which will be used as the width of the screen.</param>
    /// <param name="height">Input int which will be used as the height of the screen.</param>
    public abstract void SetWindowSize(int width, int height);

    /// <summary>
    /// Sets the title of the screen.
    /// </summary>
    /// <param name="title">Input string which will display as the title.</param>
    public abstract void SetWindowTitle(string title);

    /// <summary>
    /// Sets the position of the window.
    /// </summary>
    /// <param name="x">Input int which will be used as the destination X coordinate.</param>
    /// <param name="y">Input int which will be used as the destination Y coordinate.</param>
    public abstract void SetWindowPosition(int x, int y);

    /// <summary>
    /// Sets the windows icon.
    /// ---
    /// Loading Safety Is purely up to you or the Icon you decide to use. (might add it later)
    /// </summary>
    /// <param name="path">Provide a valid path to an icon</param>
    public abstract void SetWindowIcon(string path);

    /// <summary>
    /// Toggles the window into fullscreen mode.
    /// </summary>
    public abstract void ToggleFullscreen();

    /// <summary>
    /// Maximizes the window.
    /// </summary>
    public abstract void MaximizeWindow();

    /// <summary>
    /// Minimizes the window.
    /// </summary>
    public abstract void MinimizeWindow();

    /// <summary>
    /// Hides the cursor.
    /// </summary>
    public abstract void HideCursor();

    /// <summary>
    /// Restores the cursor.
    /// </summary>
    public abstract void ShowCursor();
}