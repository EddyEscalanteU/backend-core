namespace BackendCore.Request.Parameters
{
    /// <summary>
    /// Objeto utilizado en Fluent, deriva del body
    /// </summary>
    public interface IObject
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public object Object { get; }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetEntity<T>();
    }
}