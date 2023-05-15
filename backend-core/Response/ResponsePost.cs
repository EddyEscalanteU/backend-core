namespace Backend.Core.Response
{
    using BackendCore.Common;
    using BackendCore.Response;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Objeto resultante de una petición Post
    /// </summary>
    public class ResponsePost
    {
        /// <summary>
        /// Gets or sets the mensajes.
        /// </summary>
        /// <value>
        /// The mensajes.
        /// </value>
        public Mensaje[] Mensajes { get; set; } = new Mensaje[0];

        /// <summary>
        /// Gets or sets the respuesta.
        /// </summary>
        /// <value>
        /// The respuesta.
        /// </value>
        public ResponsePostDetail Respuesta { get; set; } = null!;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Internals the server error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static ResponsePost InternalServerErrorMessage(Exception exception)
        {
            return new ResponsePost()
            {
                Mensajes = ArrayMensaje.GetErrorMessages(exception.Message)
            };
        }

        /// <summary>
        /// Noes the content.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        /// <returns></returns>
        public static ResponsePost NoContent(ResponsePostDetail responsePostDetail)
        {
            return new ResponsePost()
            {
                Respuesta = responsePostDetail,
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// OK the specified response post detail.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        /// <param name="mensajes">The mensajes.</param>
        /// <returns></returns>
        public static ResponsePost OK(ResponsePostDetail responsePostDetail, Mensaje[]? mensajes = null)
        {
            return new ResponsePost()
            {
                Respuesta = responsePostDetail,
                Mensajes = mensajes ?? DefaultArrayMensaje.GetSuccessOK(),
                StatusCode = HttpStatusCode.OK
            };
        }

        //public static ResponsePost OK(ResponsePostDetail responsePostDetail)
        //{
        //    return new ResponsePost()
        //    {
        //        Respuesta = responsePostDetail,
        //        StatusCode = HttpStatusCode.OK
        //    };
        //}

        /// <summary>
        /// Validates the affected rows.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        /// <returns></returns>
        public static ResponsePost ValidateAffectedRows(ResponsePostDetail responsePostDetail)
        {
            if (responsePostDetail.FilasAfectadas > 0)
            {
                return OK(responsePostDetail);
            }
            else
            {
                return NoContent(responsePostDetail);
            }
        }

        /// <summary>
        /// Validates the delete data.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        /// <returns></returns>
        public static ResponsePost ValidateDeleteData(ResponsePostDetail responsePostDetail)
        {
            if (responsePostDetail.FilasAfectadas > 0)
            {
                responsePostDetail.Proceso = "Eliminado con éxito";

                return OK(responsePostDetail);
            }

            List<Mensaje> sms = new();

            var tablasReferenciadas = responsePostDetail.Proceso.Split(',');
            foreach (var item in tablasReferenciadas)
            {
                switch (item)
                {
                    case "PRIVILEGIOS":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene Privilegios asignados")); break;
                    case "USUARIOS":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene un Usuario asignado")); break;
                    case "ACTIVIDADES_HISTORIAL":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene registros en su historial")); break;
                    case "CONTACTOS":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene usuarios asignados como contacto para la actividad")); break;
                    case "RESPONSABLES":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene usuarios asignados como responsables de la actividad")); break;
                    case "ACTIVIDADES":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene actividades asignadas")); break;
                    case "CASOS_HISTORIAL":
                        sms.Add(Mensaje.InformationMessage($"[{item}] => El elemento seleccionado tiene registros en su historial")); break;
                    default:
                        sms.Add(Mensaje.InformationMessage("Falta validación para la tabla: " + item)); break;
                }
            }

            responsePostDetail.Proceso = "No es posible eliminar la información porque existen datos de referencia con las siguientes tablas de base de datos: " + responsePostDetail.Proceso;

            return OK(responsePostDetail, sms.ToArray());
        }
    }
}