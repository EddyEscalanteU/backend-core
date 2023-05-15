namespace BackendCore.Response
{
    /// <summary>
    /// Unir los objetos ResponsePostDetail
    /// </summary>
    public class JoinResponsePostDetail
    {
        private readonly List<ResponsePostDetail> responsePostDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinResponsePostDetail"/> class.
        /// </summary>
        public JoinResponsePostDetail()
        {
            responsePostDetails = new List<ResponsePostDetail>();
        }

        /// <summary>
        /// Adds the specified response post detail.
        /// </summary>
        /// <param name="responsePostDetail">The response post detail.</param>
        public void Add(ResponsePostDetail responsePostDetail)
        {
            responsePostDetails.Add(responsePostDetail);
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        public ResponsePostDetail GetResult()
        {
            int filasAfectadas = 0;
            string procesos = string.Empty;

            filasAfectadas = responsePostDetails.Sum(item => item.FilasAfectadas);
            procesos = string.Join(" _AND_ ", responsePostDetails.Select(item => item.Proceso));

            return new ResponsePostDetail(filasAfectadas, procesos);
        }
    }
}