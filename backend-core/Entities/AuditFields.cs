using System.Text.Json.Serialization;

namespace BackendCore.Entities
{
    /// <summary>
    /// Columnas de las tablas que sirven para un control de auditoria
    /// </summary>
    public class AuditFields : Identifier
    {
        /// <summary>
        /// Gets or sets the estado registro.
        /// </summary>
        /// <remarks>
        /// Se ignora el atributo para que no se muestre al Cliente
        /// </remarks>
        /// <value>
        /// The estado registro.
        /// </value>
        [JsonIgnore]
        public int EstadoRegistro { get; set; }

        /// <summary>
        /// Gets or sets the fecha borrado.
        /// </summary>
        /// <remarks>
        /// Se ignora el atributo para que no se muestre al Cliente
        /// </remarks>
        /// <value>
        /// The fecha borrado.
        /// </value>
        [JsonIgnore]
        public DateTime FechaBorrado { get; set; }

        /// <summary>
        /// Gets or sets the fecha modificación.
        /// </summary>
        /// <remarks>
        /// Se ignora el atributo para que no se muestre al Cliente
        /// </remarks>
        /// <value>
        /// The fecha modificación.
        /// </value>
        [JsonIgnore]
        public DateTime FechaModificacion { get; set; }

        /// <summary>
        /// Gets or sets the fecha registro.
        /// </summary>
        /// <remarks>
        /// Se ignora el atributo para que no se muestre al Cliente
        /// </remarks>
        /// <value>
        /// The fecha registro.
        /// </value>
        [JsonIgnore]
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Gets or sets the usuario registro.
        /// </summary>
        /// <remarks>
        /// Se ignora el atributo para que no se muestre al Cliente
        /// </remarks>
        /// <value>
        /// The usuario registro.
        /// </value>
        [JsonIgnore]
        public string? UsuarioRegistro { get; set; }
    }
}