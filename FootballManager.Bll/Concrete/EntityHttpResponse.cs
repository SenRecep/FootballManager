using System.Net;
using Newtonsoft.Json;

namespace FootballManager.Bll.Concrete
{
    public class EntityHttpResponse
    {
        public EntityHttpResponse()
        {
        }
        public EntityHttpResponse(HttpStatusCode statusCode, object data, bool status)
        {
            _Data = data;
            Jsondata = JsonConvert.SerializeObject(data);
            StatusCode = statusCode;
            IsTrue = status;
        }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public string Jsondata { get; set; }
        public object _Data { get; set; }
        public bool IsTrue { get; set; }
    }
}
