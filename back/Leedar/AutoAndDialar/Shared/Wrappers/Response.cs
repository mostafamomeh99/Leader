namespace Shared.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    public class Response<T>
    {
        private HttpStatusCode oK;
        private object userProject;

        public HttpStatusCode HttpStatusCode { get; set; }
        public bool Succeeded { get; set; }
        public NotificationMessage Message { get; set; }
        public List<string> Errors { get; set; }
        public IDictionary<string, string> ModelErrors { get; set; }
        public T Data { get; set; }
        public Exception Exception { get; set; }
        public Response()
        {
        }

        public Response(T data, NotificationMessage message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(NotificationMessage message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(HttpStatusCode httpStatusCode, T data, string message = null, List<string> errors = null)
        {
            Succeeded = true;
            Message = new NotificationMessage
            {
                Body = message
            };
            Data = data;
            HttpStatusCode = httpStatusCode;
        }
        public Response(HttpStatusCode httpStatusCode, T data, NotificationMessage message = null, Exception exception = null, List<string> errors = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            HttpStatusCode = httpStatusCode;
            Exception = exception;
            Errors = errors;
        }

        public Response(HttpStatusCode oK, object userProject)
        {
            this.oK = oK;
            this.userProject = userProject;
        }


    }
}