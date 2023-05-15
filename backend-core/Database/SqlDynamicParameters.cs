using BackendCore.Extensions;
using BackendCore.Helpers;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BackendCore.Database
{
    /// <summary>
    /// Manejo dinámico de los parámetros de SQL
    /// </summary>
    public class SqlDynamicParameters : SqlMapper.IDynamicParameters
    {

        /// <summary>
        /// The SQL parameters
        /// </summary>
        public readonly List<SqlParameter> sqlParameters = new();

        /// <summary>
        /// The dynamic parameters
        /// </summary>
        private readonly DynamicParameters dynamicParameters = new();

        /// <summary>
        /// Adds the historial.
        /// </summary>
        /// <param name="accion">The accion.</param>
        /// <param name="idUsuarioUpdate">The identifier usuario update.</param>
        private void AddHistorial(string accion, string idUsuarioUpdate)
        {
            Add(nameof(accion), accion);
            Add(nameof(idUsuarioUpdate), idUsuarioUpdate);
        }

        /// <summary>
        /// Adds the caso historial.
        /// </summary>
        /// <param name="accion">The acción.</param>
        /// <param name="idCaso">The identifier caso.</param>
        /// <param name="idUsuarioUpdate">The identifier usuario update.</param>
        public void AddCasoHistorial(string accion, string idCaso, string idUsuarioUpdate)
        {
            AddHistorial(accion, idUsuarioUpdate);
            Add(nameof(idCaso), idCaso);
        }

        /// <summary>
        /// Adds the actividad historial.
        /// </summary>
        /// <param name="accion">The acción.</param>
        /// <param name="idActividad">The identifier actividad.</param>
        /// <param name="idUsuarioUpdate">The identifier usuario update.</param>
        public void AddActividadHistorial(string accion, string idActividad, string idUsuarioUpdate)
        {
            AddHistorial(accion, idUsuarioUpdate);
            Add(nameof(idActividad), idActividad);
        }

        /// <summary>
        /// Adds the document legal historial.
        /// </summary>
        /// <param name="accion">The accion.</param>
        /// <param name="idDocLegal">The identifier document legal.</param>
        /// <param name="idUsuarioUpdate">The identifier usuario update.</param>
        public void AddDocLegalHistorial(string accion, string idDocLegal, string idUsuarioUpdate)
        {
            AddHistorial(accion, idUsuarioUpdate);
            Add(nameof(idDocLegal), idDocLegal);
        }

        /// <summary>
        /// Adds the marcas historial.
        /// </summary>
        /// <param name="accion">The accion.</param>
        /// <param name="idMarca">The identifier marca.</param>
        /// <param name="idUsuarioUpdate">The identifier usuario update.</param>
        public void AddMarcasHistorial(string accion, string idMarca, string idUsuarioUpdate)
        {
            AddHistorial(accion, idUsuarioUpdate);
            Add(nameof(idMarca), idMarca);
        }

        /// <summary>
        /// Creates the execute.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <returns></returns>
        public string CreateExecute(string storeProcedure)
        {
            StringBuilder result = new();
            result.Append(storeProcedure).Append('(');
            foreach (var parameter in sqlParameters)
            {
                if (parameter.Value is not object)
                {
                    result.Append("null,");
                }
                else
                {
                    result.Append(parameter.Value).Append(',');
                }
            }

            return result + ");";//.Remove(0, result.Length - 1) + ");";
        }

        /// <summary>
        /// Creates the execute names.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <returns></returns>
        public string CreateExecuteNames(string storeProcedure)
        {
            StringBuilder result = new();
            result.Append(storeProcedure).Append('(');
            foreach (var parameter in sqlParameters)
            {
                result.Append(parameter.ParameterName).Append(':');
                result.Append(parameter.Value).Append(',');
            }
            string result2 = result.ToString();
            result2 = result2[0..^1];

            return result2 + ");";
        }

        /// <summary>
        /// Adds the specified name attribute.
        /// </summary>
        /// <param name="parameterName">The name attribute.</param>
        /// <param name="attribute">The attribute.</param>
        /// <remarks>En caso de que el parámetro nameAttribute no contenga un valor se dispara la excepción</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(string parameterName, object attribute)
        {
            if (attribute is object)
            {
                var propertyType = attribute.GetType();
                var dbType = (propertyType.Name).GetSqlDbType();
                parameterName = parameterName.AddInput();
                SqlParameter sqlParameter = new();
                sqlParameter.ParameterName = parameterName;
                sqlParameter.DbType = dbType;
                sqlParameter.Value = attribute;
                sqlParameter.Direction = ParameterDirection.Input;

                sqlParameters.Add(sqlParameter);
            }
            else
            {
                throw new ArgumentNullException($"{parameterName} no tiene un valor");
            }
        }

        /// <summary>
        /// Adds the error message.
        /// </summary>
        public void AddErrorMessage()
        {
            AddOutput(ConstantesCore.DatabaseErros.ERROR_MESSAGE_OUTPUT, DbType.String, 2000);
        }

        /// <summary>
        /// Adds the error procedure.
        /// </summary>
        private void AddResult()
        {
            AddOutput(ConstantesCore.DatabaseProperties.RESULT_OUTPUT, DbType.String, 2000);
        }

        /// <summary>
        /// Adds the filas afectadas.
        /// </summary>
        public void AddFilasAfectadas()
        {
            AddOutput(ConstantesCore.DatabaseProperties.FILAS_AFECTADAS_OUTPUT, DbType.Int32);
        }

        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="attribute">The attribute.</param>
        public void AddInput(string parameterName, DbType dbType, object? attribute)
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.DbType = dbType;
            sqlParameter.Value = attribute;
            sqlParameter.Direction = ParameterDirection.Input;
            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adds the output.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the database.</param>
        private void AddOutput(string parameterName, DbType dbType)
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.DbType = dbType;
            sqlParameter.Direction = ParameterDirection.Output;
            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adds the output.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="size">The size.</param>
        public void AddOutput(string parameterName, DbType dbType, int size)
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = parameterName;
            sqlParameter.DbType = dbType;
            sqlParameter.Size = size;
            sqlParameter.Direction = ParameterDirection.Output;
            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adds the last identifier.
        /// </summary>
        public void AddLastId()
        {
            AddOutput(ConstantesCore.DatabaseProperties.LAST_ID_OUTPUT, DbType.Int32);
        }

        /// <summary>
        /// Removes the last identifier.
        /// </summary>
        public void RemoveLastId()
        {
            var item = sqlParameters.Find(x => x.ParameterName == ConstantesCore.DatabaseProperties.LAST_ID_OUTPUT);
            sqlParameters.Remove(item!);
        }

        /// <summary>
        /// Removes the error message.
        /// </summary>
        public void RemoveErrorMessage()
        {
            var item = sqlParameters.Find(x => x.ParameterName == ConstantesCore.DatabaseErros.ERROR_MESSAGE_OUTPUT);
            sqlParameters.Remove(item!);
        }

        /// <summary>
        /// Removes the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        public void Remove(string parameterName)
        {
            var item = sqlParameters.Find(x => x.ParameterName == parameterName.AddInput());
            sqlParameters.Remove(item!);
        }

        /// <summary>
        /// Adds the delete parameters.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="idValue">The identifier value.</param>
        public void AddDeleteParameters(string tableName, string owner, int idValue)
        {
            Add(nameof(tableName), tableName);
            Add(nameof(owner), owner);
            Add(nameof(idValue), idValue);
            AddResult();
        }

        /// <summary>
        /// Adds the parameters.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="tableOwner">The table owner.</param>
        public void AddParameters(string tableName, string tableOwner)
        {
            Add(nameof(tableName), tableName);
            Add(nameof(tableOwner), tableOwner);
            //AddCursor();
        }

        /// <summary>
        /// Adds the tamaño de pagina.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddTamanoPag(object value)
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = ConstantesCore.DatabasePaginacion.TAMANO_PAG;
            sqlParameter.DbType = DbType.Int32;
            sqlParameter.Value = value;
            sqlParameter.Direction = ParameterDirection.Input;

            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adds the numero de pagina.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddNumeroPag(object value)
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = ConstantesCore.DatabasePaginacion.NUMERO_PAG;
            sqlParameter.DbType = DbType.Int32;
            sqlParameter.Value = value;
            sqlParameter.Direction = ParameterDirection.Input;

            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adds the total registros.
        /// </summary>
        public void AddTotalRegistros()
        {
            SqlParameter sqlParameter = new();
            sqlParameter.ParameterName = ConstantesCore.DatabasePaginacion.TOTAL_REGISTROS;
            sqlParameter.DbType = DbType.Int32;
            sqlParameter.Direction = ParameterDirection.Output;

            sqlParameters.Add(sqlParameter);
        }

        /// <summary>
        /// Verifica si existe un mensaje de error
        /// </summary>
        /// <returns>true or false</returns>
        public bool ExistErrorMessage()
        {
            string errorMessage = GetErrorMessage();

            return string.IsNullOrWhiteSpace(errorMessage);
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            return GetStringParameter(ConstantesCore.DatabaseProperties.RESULT_OUTPUT);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return GetIntParameter(ConstantesCore.DatabaseProperties.RESULT_OUTPUT);
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>Parámetro de salida del procedimiento almacenado</returns>
        public string GetErrorMessage()
        {
            return GetStringParameter(ConstantesCore.DatabaseErros.ERROR_MESSAGE_OUTPUT);
        }

        /// <summary>
        /// Obtiene el parámetro de salida
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private SqlParameter GetOutputParameter(string parameterName)
        {
            var result = sqlParameters.Find(p => p.ParameterName.Equals(parameterName));

            if (result is object) return result;

            throw new ArgumentNullException($"{parameterName}: no encontrado");
        }

        /// <summary>
        /// Obtiene el valor string del parámetro de salida
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns>string value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private string GetStringParameter(string parameterName)
        {
            SqlParameter sqlParameter = GetOutputParameter(parameterName);

            var result = sqlParameter.Value.ToString();

            if (result is object) return result;

            throw new ArgumentNullException($"{parameterName}: es nulo");
        }

        /// <summary>
        /// Obtiene el valor int del parámetro de salida
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns>int value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private int GetIntParameter(string parameterName)
        {
            SqlParameter sqlParameter = GetOutputParameter(parameterName);

            var result = sqlParameter.Value.ToString();

            if (result is object)
            {
                result.CheckIntValue(parameterName);

                return result.StringToInt(parameterName);
            }
            throw new ArgumentNullException($"{parameterName}: es nulo");
        }

        /// <summary>
        /// Obtener el último id insertado
        /// </summary>
        /// <returns>int value</returns>
        public int GetLastId()
        {
            return GetIntParameter(ConstantesCore.DatabaseProperties.LAST_ID_OUTPUT);
        }

        /// <summary>
        /// Obtener las filas afectadas después de la ejecución SQL
        /// </summary>
        /// <returns>int value</returns>
        public int GetFilasAfectadas()
        {
            return GetIntParameter(ConstantesCore.DatabaseProperties.FILAS_AFECTADAS_OUTPUT);
        }

        /// <summary>
        /// Obtener el total de registros después de la ejecución SQL
        /// </summary>
        /// <returns>int value</returns>
        public int GetTotalRegistros()
        {
            return GetIntParameter(ConstantesCore.DatabasePaginacion.TOTAL_REGISTROS);
        }

        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            try
            {
                ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);
                SqlCommand? sqlCommand = command as SqlCommand;

                if (sqlCommand != null)
                {
                    sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
                }
            }
            catch (ArgumentException argumentException)
            {
                throw new ArgumentException($"{argumentException.Message}: Error al agregar un parámetro");
            }
            catch (Exception exception)
            {
                throw new NotSupportedException(exception.Message);
            }
        }
    }
}