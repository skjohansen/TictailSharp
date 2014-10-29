using System.Globalization;
using Newtonsoft.Json.Linq;
using System;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Exception to use when errors ocour in the Tictail API
    /// </summary>
    public class TictailException : Exception
    {
        /// <summary>
        /// Constructor, parses error response from Tictail
        /// </summary>
        /// <param name="responseJson">Tictail error response in JSON format</param>
        /// <param name="customMessage">An optional custom message</param>
        public TictailException(string responseJson, string customMessage = null)
        {
            dynamic response = JObject.Parse(responseJson);

            Status = response.status;
            Message = response.message;
            SupportEmail = response.support_email;
            CustomMessage = customMessage;
        }

        /// <summary>
        /// HttpStatus code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Clear text message from Tictail
        /// </summary>
        public new string Message { get; set; }

        /// <summary>
        /// A custom message, can be used to send a more personal message
        /// </summary>
        public string CustomMessage { get; set; }

        /// <summary>
        /// Email address to Tictail support
        /// </summary>
        public string SupportEmail { get; set; }

        // TODO : "params": {},                                           
    }
}
