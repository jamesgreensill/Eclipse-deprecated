using ApplicationEngine.Base.ECS;
using ApplicationEngine.Systems;

namespace ApplicationEngine.Base;

public abstract class Singleton<T> : BaseModel where T : BaseModel, new()
{
    private static T? m_Instance;

    public static T Instance
    {
        get
        {
            if (m_Instance != null)
                return m_Instance;
            m_Instance = ApplicationFactory.GetObjectOfType<T>();
            if (m_Instance != null)
                return m_Instance;
            m_Instance = ApplicationFactory.CreateObject<T>();
            return m_Instance;
        }
    }

    internal override void ApplicationInitialize()
    {
        if (m_Instance == null)
            m_Instance = this as T;
        else
        {
            ApplicationFactory.RemoveObject(this);
        }
    }
}