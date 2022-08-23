namespace ImmutableConcurrentCollections
{

    /// <summary>
    /// Thread safe collections
    /// NET Framework 4 introduced five collection types that are specially designed to support multi-threaded add and remove operations. 
    /// To achieve thread-safety, these types use various kinds of efficient locking and lock-free synchronization mechanisms.
    /// Synchronization adds overhead to an operation. 
    /// The amount of overhead depends on the kind of synchronization that is used, the kind of operations that are performed, 
    /// and other factors such as the number of threads that are trying to concurrently access the collection.
    /// </summary>
    public class ConcurrentCollections
    {
    }
}
