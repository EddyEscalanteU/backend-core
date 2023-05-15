using BackendCore.Entities;
using BackendCore.Request.Parameters;
namespace BackendCore.Request
{
    /// <summary>
    /// Cuerpo de la petición de llegada
    /// </summary>
    public abstract class RequestBody : RequestHeaders, IObject, IIdentifier
    {
        /// <summary>
        /// Gets or sets the detalle.
        /// </summary>
        /// <value>
        /// The detalle.
        /// </value>
        protected string? Detalle { get; set; }

        /// <summary>
        /// Gets the detalle.
        /// </summary>
        /// <returns></returns>
        public string GetDetalle()
        {
            return Detalle;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Identifier Id
        {
            get
            {
                var id = ((dynamic)Body).Id;
                return new Identifier() { Id = id };
            }
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public object Object
        {
            get
            {
                return Body;
            }
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        protected object? Body { get; set; }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetEntity<T>()
        {
            return (T)Body;
        }
    }
}