using Newtonsoft.Json.Linq;
using System;

namespace TictailSharp.Api.Model
{
    public class TictailException : Exception
    {
        public TictailException(string responseJson, string customMessage)
        {
            dynamic response = JObject.Parse(responseJson);

            Status = response.status;
            Message = response.message;
            SupportEmail = response.support_email;
            CustomMessage = customMessage;
        }

        public int Status { get; set; }
        public new string Message { get; set; }
        public string CustomMessage { get; set; }
        public string SupportEmail { get; set; }

        // TODO : "params": {},                                           
    }
}
