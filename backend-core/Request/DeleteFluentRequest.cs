using BackendCore.Extensions;
using BackendCore.Request.Parameters;
using Microsoft.AspNetCore.Http;

namespace BackendCore.Request
{
    /// <summary>
    /// Patron de diseño para la construcción de un objeto Fluent para eliminar objetos
    /// </summary>
    public class DeleteFluentRequest : RequestBody, ITableName
    {
        /// <summary>
        /// The table name
        /// </summary>
        private string _tableName = string.Empty;

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName
        {
            get
            {
                return _tableName;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public static DeleteFluentRequest Build()
        {
            return new DeleteFluentRequest();
        }

        /// <summary>
        /// Add properties Body and TableName From parameters
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public DeleteFluentRequest AddBodyAndTableName(object body)
        {
            Body = body;
            _tableName = (body.GetType().Name).ToSnakeCase();
            return this;
        }

        /// <summary>
        /// Adds the headers.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        public DeleteFluentRequest AddHeaders(IHeaderDictionary header)
        {
            Headers = header;
            return this;
        }

        /// <summary>
        /// Adds the detalle.
        /// </summary>
        /// <param name="detalle">The detalle.</param>
        /// <returns>El detalle asignado dentro del objeto Fluent</returns>
        public DeleteFluentRequest AddDetalle(string detalle)
        {
            Detalle = detalle;
            return this;
        }

        /// <summary>
        /// Gets the fluent request.
        /// </summary>
        /// <returns>FluentRequest object</returns>
        public FluentRequest GetFluentRequest()
        {
            return FluentRequest.Build()
                                .AddBody(Body)
                                .AddHeaders(GetHeaders())
                                .AddDetalle(Detalle);
        }
    }
}