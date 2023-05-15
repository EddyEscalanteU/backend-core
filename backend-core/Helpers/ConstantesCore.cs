namespace BackendCore.Helpers
{
    /// <summary>
    /// Constantes generales
    /// </summary>
    public static class ConstantesCore
    {
        /// <summary>
        /// The error token
        /// </summary>
        public const string ERROR_TOKEN = "El token generado está vencido.";
        /// <summary>
        /// No se encontraron datos
        /// </summary>
        public const string NO_CONTENT = "No se encontraron datos.";

        /// <summary>
        /// Acción realizada con éxito
        /// </summary>
        public const string OK = "Acción realizada con éxito";

        /// <summary>
        /// The schema CRM
        /// </summary>
        public const string SCHEMA_CRM = "db_crm";

        /// <summary>
        /// The dot
        /// </summary>
        private const string DOT = ".";

        /// <summary>
        /// Constantes de seguridad
        /// </summary>
        public static class Security
        {
            /// <summary>
            /// The security key para la encriptación
            /// </summary>
            public const string KEY = "68776CA45EBD43D9A58591D03A63CD53";
        }

        /// <summary>
        /// Error de la base de datos
        /// </summary>
        public static class DatabaseErros
        {
            /// <summary>
            /// The error message output
            /// </summary>
            public const string ERROR_MESSAGE_OUTPUT = "p_errorMessage";
        }

        /// <summary>
        /// Propiedades de la base de datos
        /// </summary>
        public static class DatabaseProperties
        {
            /// <summary>
            /// The filas afectadas output
            /// </summary>
            public const string FILAS_AFECTADAS_OUTPUT = "p_filasAfectadas";

            /// <summary>
            /// The last identifier output
            /// </summary>
            public const string LAST_ID_OUTPUT = "p_lastIdOutput";

            /// <summary>
            /// The result output
            /// </summary>
            public const string RESULT_OUTPUT = "p_result";
        }

        /// <summary>
        /// Propiedades de paginación
        /// </summary>
        public static class DatabasePaginacion
        {
            /// <summary>
            /// The numero página
            /// </summary>
            public const string NUMERO_PAG = "p_numeroDePagina";

            /// <summary>
            /// The tamaño página
            /// </summary>
            public const string TAMANO_PAG = "p_tamanoDePagina";

            /// <summary>
            /// The total registros
            /// </summary>
            public const string TOTAL_REGISTROS = "p_total_registros";
        }

        /// <summary>
        /// Gets the departamentos Bolivia.
        /// </summary>
        /// <value>
        /// The departamentos Bolivia.
        /// </value>
        public static List<string> DepartamentosBolivia
        {
            get
            {
                return new List<string>() {
                    "Santa Cruz",
                    "Cochabamba",
                    "La Paz",
                    "Oruro",
                    "Potosi",
                    "Tarija",
                    "Pando",
                    "Beni",
                    "Chuquisaca"
                };
            }
        }
    }
}