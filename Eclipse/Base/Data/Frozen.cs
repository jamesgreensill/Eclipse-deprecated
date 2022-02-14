namespace ApplicationEngine.Base.Data;

public class Frozen<T>
{
    private readonly object m_SyncLock = new();
    private readonly bool m_ThrowIfNotSet;
    private readonly string m_ValueName;
    private bool m_Set;
    private T m_Value;

    public Frozen(string valueName)
    {
        m_ValueName = valueName;
        m_ThrowIfNotSet = true;
    }

    public Frozen(string valueName, T defaultValue)
    {
        m_ValueName = valueName;
        m_Value = defaultValue;
    }

    public T Value
    {
        get
        {
            lock (m_SyncLock)
            {
                if (!m_Set && m_ThrowIfNotSet) throw new ValueNotSetException(m_ValueName);
                return m_Value;
            }
        }
        set
        {
            lock (m_SyncLock)
            {
                if (m_Set) throw new AlreadySetException(m_ValueName);
                m_Set = true;
                m_Value = value;
            }
        }
    }

    public static implicit operator T(Frozen<T> toConvert)
    {
        return toConvert.m_Value;
    }
}

public class NamedValueException : InvalidOperationException
{
    public NamedValueException(string valueName, string messageFormat)
        : base(string.Format(messageFormat, valueName))
    {
        ValueName = valueName;
    }

    public string ValueName { get; }
}

public class AlreadySetException : NamedValueException
{
    private const string MESSAGE = "The value \"{0}\" has already been set.";

    public AlreadySetException(string valueName)
        : base(valueName, MESSAGE)
    {
    }
}

public class ValueNotSetException : NamedValueException
{
    private const string MESSAGE = "The value \"{0}\" has not yet been set.";

    public ValueNotSetException(string valueName)
        : base(valueName, MESSAGE)
    {
    }
}