using BackendCore.Enums;
using BackendCore.Request;
using BackendCore.Response;

namespace BackendCore.Interfaces.Connection
{
    /// <summary>
    /// Interfaz para el registro de actividades a la base de datos
    /// </summary>
    public interface IWriteConexionWithBitacora
    {
        #region Methods

        /// <summary>
        /// Attaches the bitacora detalle.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        /// <param name="fluentRequest">The fluent request.</param>
        /// <param name="actionCommandType">Type of the action command.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="FormatException"></exception>
        Task AttachBitacoraDetalle(ResponsePostDetail responsePostDetail, FluentRequest fluentRequest, TypeActionCommand actionCommandType);

        //Task AttachBitacorasList<T>(FluentRequest fluentRequest, TypeActionCommand actionCommandType);

        #endregion Methods
    }
}