using BackendCore.Entities;

namespace BackendCore.Common
{
    /// <summary>
    /// Clase para cargar la información de los Select o ComboBox
    /// </summary>
    public class Select : Identifier
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string? Value { get; set; }
    }
}
