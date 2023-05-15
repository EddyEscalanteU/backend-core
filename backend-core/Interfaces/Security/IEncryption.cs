using BackendCore.Entities;

namespace BackendCore.Interfaces.Security
{
    /// <summary>
    /// Interfaz para la capa de seguridad de los datos
    /// </summary>
    public interface IEncryption
    {
        /// <summary>
        /// Desencriptar the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string Desencriptar(string text, string key);

        /// <summary>
        /// Encrypts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        string Encrypt(string id);

        /// <summary>
        /// Decrypts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        string Decrypt(string id);

        /// <summary>
        /// Decrypts the parameter identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        int DecryptParameterId(string id);

        /// <summary>
        /// Decrypts the parameter identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        int DecryptParameterIdentifier(Identifier identifier);

        /// <summary>
        /// Desencriptar the identifier and FK.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        object DesencriptarIdAndFk(object item);

        /// <summary>
        /// Desencriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        T DesencriptarIdAndFk<T>(object item);

        /// <summary>
        /// Encriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="resultFk">The result FK.</param>
        /// <returns></returns>
        IEnumerable<T> EncriptarIdAndFk<T>(IEnumerable<T> result, IEnumerable<dynamic> resultFk);

        /// <summary>
        /// Encriptar los ids de un array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        IEnumerable<T> EncriptarIds<T>(IEnumerable<T> result);

        /// <summary>
        /// Encriptar the identifier and FK.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="resultFk">The result FK.</param>
        /// <returns></returns>
        T EncriptarObjIdAndFk<T>(T item, IEnumerable<dynamic> resultFk);

        /// <summary>
        /// Encriptar the ids de un objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        T EncriptarIdsObj<T>(T item);
    }
}
