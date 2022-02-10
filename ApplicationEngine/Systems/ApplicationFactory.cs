using ApplicationEngine.Base;

namespace ApplicationEngine.Systems;

public static class ApplicationFactory
{
    public static readonly List<BaseModel> Objects = new();

    /// <summary>
    /// Add a new object to the application.
    /// </summary>
    /// <param name="obj"></param>
    public static void AddObject(BaseModel obj) => Objects.Add(obj);

    /// <summary>
    /// Add a collection of objects to the application.
    /// </summary>
    /// <param name="objs"></param>
    public static void AddObjects(IEnumerable<BaseModel> objs) => Objects.AddRange(objs);

    /// <summary>
    /// Remove an object from the application.
    /// </summary>
    /// <param name="obj"></param>
    public static void RemoveObject(BaseModel obj) => Objects.Remove(obj);

    /// <summary>
    /// Remove object at index from the application.
    /// </summary>
    /// <param name="index"></param>
    public static void RemoveObject(int index) => Objects.RemoveAt(index);

    /// <summary>
    /// Remove all objects from the application.
    /// </summary>
    public static void RemoveAllObjects() => Objects.Clear();

    /// <summary>
    /// Remove all objects that are of Type T
    /// </summary>
    /// <typeparam name="T">T must Inherit from BaseModel</typeparam>
    public static void RemoveAllObjects<T>() where T : BaseModel => Objects.RemoveAll(x => x is T);

    /// <summary>
    /// Remove all objects that match the Predicate.
    /// </summary>
    /// <param name="match">A Specified Criteria</param>
    /// <typeparam name="T">T must inherit from BaseModel</typeparam>
    public static void RemoveAllObjects<T>(Predicate<T> match) where T : BaseModel =>
        Objects.RemoveAll(x => x is T model && match(model));

    /// <summary>
    /// Gets all objects that are of Type T
    /// </summary>
    /// <typeparam name="T">Type T must inherit from BaseModel</typeparam>
    /// <returns>An Array containing all arguments Matching type T</returns>
    public static T[] GetObjects<T>() where T : BaseModel => Objects.FindAll(x => x is T).Cast<T>().ToArray();

    /// <summary>
    /// Gets all objects that match the Predicate.
    /// </summary>
    /// <param name="match">A set criteria to match</param>
    /// <typeparam name="T">Type T must inherit from BaseModel</typeparam>
    /// <returns>An Array containing all arguments Matching type T</returns>
    public static T[] GetObjects<T>(Predicate<T> match) where T : BaseModel =>
        Objects.FindAll(x => x is T model && match(model)).Cast<T>().ToArray();
}