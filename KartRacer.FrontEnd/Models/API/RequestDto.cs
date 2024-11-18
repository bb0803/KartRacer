using System.Security.AccessControl;

namespace KartRacer.FrontEnd.Models.API
{
    public class RequestDto
    {
        public string ApiType { get; set; } = "Get";
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public string ContentType { get; set; } = "Json";
    }
}
