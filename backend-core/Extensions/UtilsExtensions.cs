using BackendCore.Enums;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace BackendCore.Extensions
{
    /// <summary>
    /// Extension con métodos útiles para los sistemas.
    /// </summary>
    public static class UtilsExtensions
    {
        /// <summary>
        /// Removes the CRLF from string.
        /// </summary>
        /// <param name="pString">The p string.</param>
        /// <returns></returns>
        public static string RemoveCRLFFromString(this string pString)
        {
            //Return empty string if null passed
            if (pString == null)
                return "";

            //Remove carriage returns
            return pString.Replace("\n", "").Replace("\r", "");
        }

        /// <summary>
        /// Objects to JSON.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string ObjectToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JSON to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static T JSONToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json)!;
        }

        /// <summary>
        /// Convertir un objeto en Base64
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Base64</returns>
        public static string Base64EncodeObject(this object obj)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Strings to base64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string StringToBase64(this string value)
        {
            if ((value == null))
                value = "";
            value = value.Trim();
            if ((value.Length > 0))
                value = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(value));
            return value;
        }


        /// <summary>
        /// Convertir Base64 en un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="base64String">The base64 string.</param>
        /// <returns>objeto</returns>
        public static T Base64DecodeObject<T>(this string base64String)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(base64String);
            T? result = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(base64EncodedBytes));
            if (result is null)
            {
                throw new ArgumentNullException(base64String, "No se puede convertir un valor (base64) NULO a objeto");
            }
            return result;
        }

        /// <summary>
        /// Converts to size.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        public static double ToSize(this Int64 value, TypeSizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));//.ToString("0.00");
        }

        /// <summary>
        /// Validates the string.
        /// </summary>
        /// <remarks>En caso de ser nulo o con espacios en blanco, retorna un string vació</remarks>
        /// <param name="value">The value.</param>
        /// <returns>El valor del string ya validado</returns>
        public static string ValidateString(this string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        /// <summary>
        /// Validates the positive.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="nameOfValue"></param>
        /// <exception cref="System.ArgumentException">'{number}' no puede tener un valor negativo.</exception>
        public static void ValidatePositive(this int number, string nameOfValue)
        {
            if (number < 0)
            {
                throw new ArgumentException($"'{number}' no puede tener un valor negativo.", nameOfValue);
            }
        }

        /// <summary>
        /// Checks the string value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nameOfValue">The name of value.</param>
        /// <exception cref="ArgumentException">'{nameOfValue}' no puede ser nulo ni estar vacío.</exception>
        public static void CheckStringValue(this string value, string nameOfValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameOfValue}' no puede ser nulo ni estar vacío.", nameOfValue);
            }
        }

        /// <summary>
        /// Checks the int value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nameOfValue">The name of value.</param>
        /// <exception cref="ArgumentException">'{nameOfValue}' no puede ser nulo ni estar vacío.</exception>
        public static void CheckIntValue(this string value, string nameOfValue)
        {
            if (!int.TryParse(value, out int _))
            {
                throw new ArgumentException($"'{nameOfValue}' no puede ser nulo ni estar vacío.", nameOfValue);
            }
        }

        /// <summary>
        /// Convert string to int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="nameOfValue">The name of value.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public static int StringToInt(this string value, string nameOfValue)
        {
            if (int.TryParse(value, out int parameter))
            {
                return parameter;
            }
            throw new NotSupportedException($"{nameOfValue}: El intento de conversión de'{value ?? "<null>"}' ha fallado");
        }

        /// <summary>
        /// Determines whether the specified enum type is enum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="enumType">Type of the enum.</param>
        /// <exception cref="ArgumentException">'{value}' no es un valor permitido, solamente los siguientes: " + printAllValues</exception>
        public static void IsEnum(this string value, Type enumType)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                string printAllValues = string.Join(", ", Enum.GetNames(enumType));
                throw new ArgumentException($"'{value}' no es un valor permitido, solamente los siguientes: " + printAllValues, value);
            }
        }
        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="texto">The texto.</param>
        /// <returns>p_texto</returns>
        public static string AddInput(this string texto)
        {
            return $"p_{texto}";
        }

        /// <summary>
        /// Adds the schema.
        /// </summary>
        /// <param name="texto">The texto.</param>
        /// <returns>p_texto</returns>
        public static string AddSchema(this string texto)
        {
            return $"db_crm.{texto}";
        }

        /// <summary>
        /// Obtener el nombre de la clase
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Objeto con valor nulo para obtener el nombre de la clase</exception>
        public static string GetClassName(this object? obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException("Objeto con valor nulo para obtener el nombre de la clase");
            }
            else
            {
                return obj.GetType().Name;
            }
        }

        /// <summary>
        /// Removes the last character.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>La misma cadena sin el ultimo carácter</returns>
        public static string RemoveLastCharacter(this string text)
        {
            if (text.Length < 1) return text;
            return text.Remove(text.Length - 1, 1);
        }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">text</exception>
        public static string GetSchema(this string text)
        {
            if (text is object)
            {
                int punto = text.IndexOf('.');
                if (punto.Equals(-1))
                {
                    return text;
                }
                return text.Substring(0, punto);
            }
            throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Removes the schema.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">text</exception>
        public static string RemoveSchema(this string text)
        {
            if (text is object)
            {
                int punto = text.IndexOf('.');
                if (punto.Equals(-1))
                {
                    return text;
                }
                string result = text.Remove(0, punto + 1);
                return result;
            }
            throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Snakes the case to camel case.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string SnakeCaseToCamelCase(this string text)
        {
            return (text.ToLower()).Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => char.ToUpperInvariant(s[0]) + s[1..])
                .Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        /// <summary>
        /// Converts to SnakeCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">text</exception>
        public static string ToSnakeCase(this string text)
        {
            if (text is object)
            {
                if (text.Length < 2)
                {
                    return text;
                }
                var sb = new StringBuilder();
                sb.Append(char.ToLowerInvariant(text[0]));
                for (int i = 1; i < text.Length; ++i)
                {
                    char c = text[i];
                    if (char.IsUpper(c))
                    {
                        sb.Append('_');
                        sb.Append(char.ToLowerInvariant(c));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                return (sb.ToString()).ToUpper();
            }
            throw new ArgumentNullException(nameof(text));
        }
    }
}