using BackendCore.Database;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace BackendCore.Extensions
{
    /// <summary>
    /// Métodos de extension para SQL
    /// </summary>
    public static class SqlExtensions
    {
        /// <summary>
        /// Obtiene los meta datos de una class y los agrega como OracleDynamicParameters
        /// </summary>
        /// <param parameterName="obj">The object.</param>
        /// <returns></returns>
        public static SqlDynamicParameters GetMetadata(this object obj)
        {
            var parametros = new SqlDynamicParameters();
            Type _type = obj.GetType();

            foreach (PropertyInfo F in _type.GetProperties())
            {
                switch (F.PropertyType.Name)
                {
                    case "String":
                    case "Int32":
                    case "Double":
                    case "DateTime":
                    case "Boolean":
                    case "Identificador":
                        DbType oracleDbType = GetSqlDbType(F.PropertyType.Name);
                        string parameterName = (F.Name).AddInput();
                        object? attribute = F.GetValue(obj);
                        parametros.AddInput(parameterName, oracleDbType, attribute);
                        break;
                }
            }
            return parametros.AddDefaultParameters();
        }

        /// <summary>
        /// Convierte el nombre del tipo de dato en string a su equivalente en OracleDbType
        /// </summary>
        /// <param name="PropertyTypeName">int</param>
        /// <returns>OracleDbType.Int32</returns>
        public static DbType GetSqlDbType(this string PropertyTypeName)
        {
            return PropertyTypeName switch
            {
                "String" => DbType.String,
                "Int32" => DbType.Int32,
                "Double" => DbType.Double,
                "Decimal" => DbType.Decimal,
                "DateTime" => DbType.Date,
                "Boolean" => DbType.Int32,
                "Identificador" => DbType.Int32,
                "Byte[]" => DbType.Binary,
                _ => throw new ArgumentNullException(PropertyTypeName),
            };
        }

        /// <summary>
        /// Mostrar los parámetros.
        /// </summary>
        /// <param name="oracleParameters">The oracle parameters.</param>
        /// <returns></returns>
        public static string MostrarParametros(this List<SqlParameter> oracleParameters)
        {
            StringBuilder result = new();
            foreach (var parameter in oracleParameters)
            {
                result.Append(parameter.ParameterName).Append(" : ").Append(parameter.Value).Append(", ");
            }
            return result.ToString();
        }

        /// <summary>
        /// Adds the default parameters.
        /// </summary>
        /// <param name="entityParameters">The entity parameters.</param>
        /// <returns></returns>
        public static SqlDynamicParameters AddDefaultParameters(this SqlDynamicParameters entityParameters)
        {
            //entityParameters.AddErrorNumber();
            //entityParameters.AddErrorState();
            //entityParameters.AddErrorSeverity();
            //entityParameters.AddErrorProcedure();
            //entityParameters.AddErrorLine();
            entityParameters.AddErrorMessage();
            //entityParameters.AddFilasAfectadas();
            return entityParameters;
        }
    }
}