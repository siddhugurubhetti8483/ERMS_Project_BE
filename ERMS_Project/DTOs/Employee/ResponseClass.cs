using System.Net;

namespace ERMS_Project.DTOs.Employee
{
    public class ResponseClass
    {
        public string? message { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public dynamic? data { get; set; }
    }
}