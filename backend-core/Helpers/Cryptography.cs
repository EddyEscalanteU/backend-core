using System.Security.Cryptography;
using System.Text;

namespace BackendCore.Helpers
{
    /// <summary>
    /// Objeto para encriptar y desencriptar valores en todo el sistema
    /// </summary>
    public static class Cryptography
    {
        #region "Criptografía"

        /// <summary>
        /// Decrypts the parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">El valor a desencriptar, no es valido " + exception.ToString()</exception>
        public static string DecryptParameter(string value, string key)
        {
            try
            {
                return Desencriptar(value, key);
            }
            catch (Exception exception)
            {
                throw new ArgumentException("El valor a desencriptar, no es valido " + exception.ToString(), exception);
            }
        }

        /// <summary>
        /// Decrypts the parameter identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string DecryptParameterId(string? value)
        {
            if (value is null)
            {
                throw new ArgumentException("{value}: El valor a desencriptar, no es valido");
            }

            return Desencriptar(value, ConstantesCore.Security.KEY);
        }

        /// <summary>
        /// Encrypts the parameter identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncryptParameterId(string? value)
        {
            if (value is null)
            {
                throw new ArgumentException("{value}: El valor a encriptar, no es valido");
            }

            return Encriptar(value, ConstantesCore.Security.KEY);
        }

        /// <summary>
        /// Encriptar the specified ls text.
        /// </summary>
        /// <param name="lsText">The ls text.</param>
        /// <param name="lsKeyc">The ls key.</param>
        /// <returns></returns>
        public static string Encriptar(string lsText, string lsKeyc)
        {
            if ((lsKeyc.Length > 8))
                lsKeyc = lsKeyc.Substring(0, 8);
            else if ((lsKeyc.Length < 8))
                lsKeyc = lsKeyc.PadLeft(8, '$');

            byte[] IV = ASCIIEncoding.ASCII.GetBytes(lsKeyc); // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Encoding.UTF8.GetBytes(lsText);

#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
            des.Key = EncryptionKey;
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        /// <summary>
        /// Desencriptar the specified ls text.
        /// </summary>
        /// <param name="lsText">The ls text.</param>
        /// <param name="lsKeyc">The ls key.</param>
        /// <returns></returns>
        public static string Desencriptar(string lsText, string lsKeyc)
        {
            if ((lsKeyc.Length > 8))
                lsKeyc = lsKeyc.Substring(0, 8);
            else if ((lsKeyc.Length < 8))
                lsKeyc = lsKeyc.PadLeft(8, '$');
            byte[] IV = ASCIIEncoding.ASCII.GetBytes(lsKeyc); // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Convert.FromBase64String(lsText);
#pragma warning disable SYSLIB0021 // El tipo o el miembro están obsoletos
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
#pragma warning restore SYSLIB0021 // El tipo o el miembro están obsoletos
            des.Key = EncryptionKey;
            des.IV = IV;
            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        #endregion "Criptografía"
        /*
        public static string Base64EncodeStreamObject(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public static T Base64DecodeStreamObject<T>(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }
        public static string EncryptStringV2(string plainInput)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(ConstantesCore.SECURITY_KEY);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptStringV2(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(ConstantesCore.SECURITY_KEY);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }

        }

        public static string EncryptString(string text)
        {
            var key = Encoding.UTF8.GetBytes(ConstantesCore.SECURITY_KEY);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(ConstantesCore.SECURITY_KEY);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }*/
    }
}
