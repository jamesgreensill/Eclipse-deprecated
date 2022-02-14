using ApplicationEngine.Extensions;

namespace ApplicationEngine.Base.ECS;

public class ApplicationEntity : BaseModel
{
    private uint m_Id;
    private readonly Dictionary<Guid, ApplicationComponent?> m_Components;

    /// <summary>
    /// Constructor for the application entity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="components"></param>
    public ApplicationEntity(uint id, ApplicationComponent[]? components = null)
    {
        m_Id = id;
        m_Components = (components != null
            ? components.ToDictionary(c => c.GetType().GUID)!
            : new Dictionary<Guid, ApplicationComponent?>()!)!;
    }

    /// <summary>
    /// Add component to entity using a component type generics based model
    /// </summary>
    /// <param name="component">Input parameter to add pre-existing component.</param>
    /// <typeparam name="T">Type Component must inherit from class ApplicationComponent</typeparam>
    /// <returns>Parsed or Pre-existing Component.</returns>
    public T? AddComponent<T>(T component, bool getExisting = false) where T : ApplicationComponent
        => m_Components.TryAdd(typeof(T).GUID, component) ? component :
            getExisting ? (T)m_Components[typeof(T).GUID]! : null;

    /// <summary>
    /// Add component to entity by creating a new instance of the component of type T.
    /// </summary>
    /// <typeparam name="T">Type component must inherit from class ApplicationComponent</typeparam>
    /// <returns>Created or pre-existing component.</returns>
    public T? AddComponent<T>(bool getExisting = false) where T : ApplicationComponent, new() =>
        AddComponent(new T(), getExisting);

    /// <summary>
    /// Adds multiple components to the entity.
    /// </summary>
    /// <param name="components">A list of pre-existing components.</param>
    public void AddComponents(IEnumerable<ApplicationComponent> components) => components.ForEach(c => AddComponent(c));

    /// <summary>
    /// Get component of type T from entity.
    /// </summary>
    /// <typeparam name="T">T must inherit from ApplicationComponent</typeparam>
    /// <returns>returns component of Type T if it exists.</returns>
    public ApplicationComponent? GetComponent<T>() where T : ApplicationComponent =>
        m_Components.TryGetValue(typeof(T).GUID, out var component) ? component : null;

    internal override void ApplicationStart() => m_Components.ForEach(c => c.Value?.ApplicationStart());
    internal override void ApplicationTick() => m_Components.ForEach(c => c.Value?.ApplicationTick());
    internal override void ApplicationLateTick() => m_Components.ForEach(c => c.Value?.ApplicationLateTick());
    internal override void ApplicationDraw() => m_Components.ForEach(c => c.Value?.ApplicationDraw());
    internal override void ApplicationEnd() => m_Components.ForEach(c => c.Value?.ApplicationEnd());
    internal override void ApplicationInitialize() => m_Components.ForEach(c => c.Value?.ApplicationInitialize());
}