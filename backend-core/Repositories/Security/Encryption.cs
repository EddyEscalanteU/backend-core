using BackendCore.Entities;
using BackendCore.Extensions;
using BackendCore.Helpers;
using BackendCore.Interfaces.Security;
using System.Reflection;

namespace BackendCore.Repositories.Security
{
    /// <summary>
    /// Encriptar a nivel de objeto
    /// </summary>
    public class Encryption : IEncryption
    {
        /// <summary>
        /// Desencriptar the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">El intento de conversión de  ha fallado al momento de revertir la encriptación - value</exception>
        public string Desencriptar(string text, string key)
        {
            string value = Cryptography.DecryptParameter(text, key);
            return value;

            throw new ArgumentException($"El intento de conversión de '{value ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(value));
        }

        /// <summary>
        /// Encrypts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">El intento de conversión de '{value ?? "null"}' ha fallado, al momento de revertir la encriptación - value</exception>
        public string Encrypt(string id)
        {
            string value = Cryptography.EncryptParameterId(id);
            return value;

            throw new ArgumentException($"El intento de conversión de '{value ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(value));
        }

        /// <summary>
        /// Decrypts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">El intento de conversión de '{value ?? "null"}' ha fallado, al momento de revertir la encriptación - value</exception>
        public string Decrypt(string id)
        {
            string value = Cryptography.DecryptParameterId(id);
            return value;

            throw new ArgumentException($"El intento de conversión de '{value ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(value));
        }

        /// <summary>
        /// Decrypts the parameter identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">El intento de conversión de '{value ?? "null"}' ha fallado, al momento de revertir la encriptación - value</exception>
        public int DecryptParameterId(string id)
        {
            string value = Cryptography.DecryptParameterId(id);
            if (int.TryParse(value, out int parameter))
            {
                return parameter;
            }

            throw new ArgumentException($"El intento de conversión de '{value ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(value));
        }

        /// <summary>
        /// Decrypts the parameter identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">El intento de conversión de '{value ?? "null"}' ha fallado, al momento de revertir la encriptación</exception>
        public int DecryptParameterIdentifier(Identifier identifier)
        {
            if (identifier.Id is null)
            {
                throw new ArgumentException($"El intento de conversión de '{identifier.Id ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(identifier.Id));
            }
            string value = Cryptography.DecryptParameterId(identifier.Id);
            if (int.TryParse(value, out int parameter))
            {
                return parameter;
            }

            throw new ArgumentException($"El intento de conversión de '{value ?? "<null>"}' ha fallado, al momento de revertir la encriptación", nameof(value));
        }

        /// <summary>
        /// Desencriptar the identifier and FK.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">El objeto a desencriptar no tiene un valor</exception>
        public object DesencriptarIdAndFk(object item)
        {
            if (item is object)
            {
                Type _type = item.GetType();
                PropertyInfo[] listaPropiedades = _type.GetProperties();

                var propertiesInfo = (from F in listaPropiedades
                                      where ((F.Name).Substring(0, 2)).Equals("Id")
                                      select F);

                foreach (var propertyInfo in propertiesInfo)
                {
                    object? value = propertyInfo.GetValue(item);
                    if (value is not null)
                    {
                        var EncryptedValue = Cryptography.DecryptParameterId(value.ToString());
                        item?.GetType()?.GetProperty(propertyInfo.Name)?.SetValue(item, EncryptedValue);
                    }
                }
                return item;
            }
            throw new NotSupportedException("El objeto a desencriptar no tiene un valor");
        }

        /// <summary>
        /// Desencriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">El objeto a desencriptar no tiene un valor</exception>
        public T DesencriptarIdAndFk<T>(object item)
        {
            if (item is object)
            {
                Type _type = item.GetType();
                PropertyInfo[] listaPropiedades = _type.GetProperties();

                var propertiesInfo = (from F in listaPropiedades
                                      where ((F.Name).Substring(0, 2)).Equals("Id")
                                      select F);

                foreach (var propertyInfo in propertiesInfo)
                {
                    object? value = propertyInfo.GetValue(item);
                    if (value is not null)
                    {
                        var EncryptedValue = Cryptography.DecryptParameterId(value.ToString());
                        item?.GetType()?.GetProperty(propertyInfo.Name)?.SetValue(item, EncryptedValue);
                    }
                }
                return (T)item;
            }
            throw new NotSupportedException("El objeto a desencriptar no tiene un valor");
        }

        /// <summary>
        /// Encriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="resultFk">The result FK.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">El objeto no tiene las mismas FK para poder Encriptarse</exception>
        public IEnumerable<T> EncriptarIdAndFk<T>(IEnumerable<T> result, IEnumerable<dynamic> resultFk)
        {
            result = EncriptarIds<T>(result);

            if (resultFk.Any())
            {
                foreach (var item in result)
                {
                    if (item is not null)
                    {
                        Type _type = item.GetType();
                        PropertyInfo[] listaPropiedades = _type.GetProperties();

                        foreach (IDictionary<string, object> rowFk in resultFk.OfType<IDictionary<string, object>>())
                        {
                            try
                            {
                                var itemRowFk = (from pairFk in rowFk
                                                 where pairFk.Key == "COLUMN_NAME"
                                                 select pairFk).FirstOrDefault();

                                var propertyInfo = (from F in listaPropiedades
                                                    where (F.Name.ToSnakeCase()).ToUpper().Equals(itemRowFk.Value)
                                                    select F).FirstOrDefault();

                                if (propertyInfo != null)
                                {
                                    object? value = propertyInfo.GetValue(item);

                                    if (value is not null)
                                    {
                                        var idEncriptado = Cryptography.EncryptParameterId(value.ToString());
                                        item?.GetType()?.GetProperty(propertyInfo.Name)?.SetValue(item, idEncriptado);
                                    }
                                }
                                else
                                {
                                    throw new NotSupportedException("La información de la propiedad del objeto a encriptarse es NULL");
                                }
                            }
                            catch (Exception exception)
                            {
                                throw new NotSupportedException("El objeto no tiene las mismas FK para poder Encriptarse", exception);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Encriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="resultFk">The result FK.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">
        /// La información de la propiedad del objeto a encriptarse es NULL
        /// or
        /// El objeto no tiene las mismas FK para poder Encriptarse
        /// </exception>
        public T EncriptarObjIdAndFk<T>(T item, IEnumerable<dynamic> resultFk)
        {
            item = EncriptarIdsObj<T>(item);

            if (resultFk.Any())
            {
                if (item is not null)
                {
                    Type _type = item.GetType();
                    PropertyInfo[] listaPropiedades = _type.GetProperties();

                    foreach (IDictionary<string, object> rowFk in resultFk.OfType<IDictionary<string, object>>())
                    {
                        try
                        {
                            var itemRowFk = (from pairFk in rowFk
                                             where pairFk.Key == "COLUMN_NAME"
                                             select pairFk).FirstOrDefault();

                            var propertyInfo = (from F in listaPropiedades
                                                where (F.Name.ToSnakeCase()).ToUpper().Equals(itemRowFk.Value)
                                                select F).FirstOrDefault();

                            if (propertyInfo != null)
                            {
                                object? value = propertyInfo.GetValue(item);

                                if (value is not null)
                                {
                                    var idEncriptado = Cryptography.EncryptParameterId(value.ToString());
                                    item?.GetType()?.GetProperty(propertyInfo.Name)?.SetValue(item, idEncriptado);
                                }
                            }
                            else
                            {
                                throw new NotSupportedException("La información de la propiedad del objeto a encriptarse es NULL");
                            }
                        }
                        catch (Exception exception)
                        {
                            throw new NotSupportedException("El objeto no tiene las mismas FK para poder Encriptarse", exception);
                        }
                    }
                }
            }
            return item;
        }

        /// <summary>
        /// Encriptar los ids de un array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public IEnumerable<T> EncriptarIds<T>(IEnumerable<T> result)
        {
            foreach (var item in result)
            {
                EncriptarIdsObj(item);
            }
            return result;
        }

        /// <summary>
        /// Encriptar the ids de un objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public T EncriptarIdsObj<T>(T item)
        {
            if (item is not null)
            {
                Type _type = item.GetType();
                PropertyInfo[] listaPropiedades = _type.GetProperties();

                var propertyInfo = (from F in listaPropiedades
                                    where (F.Name).Equals("Id")
                                    select F).FirstOrDefault();

                if (propertyInfo is object)
                {
                    object? value = propertyInfo.GetValue(item);
                    if (value is not null)
                    {
                        var idEncriptado = Cryptography.EncryptParameterId(value.ToString());
                        item?.GetType()?.GetProperty(propertyInfo.Name)?.SetValue(item, idEncriptado);
                    }
                }
            }
            return item;
        }
    }
}