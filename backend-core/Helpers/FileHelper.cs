using System.Reflection;

namespace BackendCore.Helpers
{
    /// <summary>
    /// Métodos útiles para el manejo de archivos de los sistemas.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Gets the embedded resource.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="ns">The ns.</param>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public static string GetEmbeddedResource(Assembly assembly, string ns, string resource)
        {
            try
            {
                string resourceName = string.Format("{0}.{1}", ns, resource);
                Stream? stream = assembly.GetManifestResourceStream(resourceName);
                using (var reader = new StreamReader(stream!))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                throw new NotSupportedException(exception.Message);
            }
        }

        /// <summary>
        /// Gets the DLL folder.
        /// </summary>
        /// <returns></returns>
        public static string? GetDllFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Gets the project folder.
        /// </summary>
        /// <returns></returns>
        public static string GetProjectFolder()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory;
        }

        /// <summary>
        /// Adds the folder to path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        public static string AddFolderToPath(this string path, string folder)
        {
            return Path.Combine(path, folder);
        }

        /// <summary>
        /// Adds the file to path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static string AddFileToPath(this string path, string file)
        {
            return Path.Combine(path, file);
        }

        /// <summary>
        /// Creates the folder.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void CreateFolder(string path)
        {
            if (!ExistFolder(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Exists the folder.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static bool ExistFolder(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Moves up.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="noOfLevels">The no of levels.</param>
        /// <returns>La carpeta del nivel anterior</returns>
        public static string MoveUp(string path, int noOfLevels)
        {
            string parentPath = path.TrimEnd(new[] { '/', '\\' });
            for (int i = 0; i < noOfLevels; i++)
            {
                parentPath = Directory.GetParent(parentPath)!.ToString();
            }
            return parentPath;
        }
    }
}