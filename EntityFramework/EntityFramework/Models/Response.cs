using System.Net;

namespace EntityFramework.Models
{
    public class Response<T>
    {
        #region Constructors
        public Response()
        {
            StatusCode = HttpStatusCode.OK;
            Message = new List<string>();
            RequestTime = DateTime.Now;
        }

        public Response(T data, string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Data = data;
            StatusCode = statusCode;
            Message = new List<string>();
            if (!string.IsNullOrEmpty(message))
                Message.Add(message);
            else
                Message.Add("Success");
            RequestTime = DateTime.Now;
        }

        #endregion

        #region Public Properties
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Message { get; set; }
        public DateTime RequestTime { get; set; }
        #endregion
    }
}
