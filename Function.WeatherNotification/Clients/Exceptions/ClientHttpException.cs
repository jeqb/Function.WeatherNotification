using System;
using System.Net;

namespace Function.WeatherNotification.Clients.Exceptions
{
    public class ClientHttpException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ClientHttpException() { }

        public ClientHttpException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ClientHttpException(string message, Exception inner) : base(message, inner) { }
    }
}
