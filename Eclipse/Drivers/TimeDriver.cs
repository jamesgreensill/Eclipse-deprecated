using System.Diagnostics;
using ApplicationEngine.Base;

namespace ApplicationEngine.Drivers;

public class TimeDriver : Singleton<TimeDriver>
{
    #region Member Variables

    // time piece.
    private Stopwatch m_stopwatch = new Stopwatch();

    // elpased time.
    private long m_currentTime = 0;
    private long m_lastTime = 0;

    private float m_timer = 0;
    private float m_deltaTime = 0.0005f;

    // frames per second.
    private int m_fps = 1;

    // amount of frames.
    private int m_frames;

    #endregion Member Variables

    #region Properties

    public long CurrentTime
    {
        get => m_currentTime;
        set => m_currentTime = value;
    }

    public long LastTime
    {
        get => m_lastTime;
        set => m_lastTime = value;
    }

    public float Timer
    {
        get => m_timer;
        set => m_timer = value;
    }

    public int FPS
    {
        get => m_fps;
        set => m_fps = value;
    }

    public int Frames
    {
        get => m_frames;
        set => m_frames = value;
    }

    public float DeltaTime
    {
        get => m_deltaTime;
        set => m_deltaTime = value;
    }

    #endregion Properties

    #region Functions

    internal override void ApplicationTick()
    {
        CurrentTime = m_stopwatch.ElapsedMilliseconds;

        DeltaTime = (CurrentTime - LastTime) / 1000f;

        Timer += DeltaTime;

        if (Timer >= 1)
        {
            FPS = Frames;
            Frames = 0;
            Timer -= 1;
        }

        Frames++;

        LastTime = CurrentTime;
    }

    internal override void ApplicationInitialize()
    {
        base.ApplicationInitialize();
        m_stopwatch.Start();
    }


    #endregion Functions
}