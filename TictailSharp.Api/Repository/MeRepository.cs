using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Me;

namespace TictailSharp.Api.Repository
{
    /// <summary>
    /// Me repository
    /// </summary>
    public class MeRepository : IMeRepository
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Me repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        public MeRepository(ITictailClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get Me from Tictail API
        /// </summary>
        /// <returns>A Me, describing the current store</returns>
        public Me Get()
        {
            var request = new RestRequest("v1/me", Method.GET);
            try
            {
                return DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.OK).Content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Me found");
            }
        }

        /// <summary>
        /// Deserilize the Me data fetched from the Tictail API
        /// </summary>
        /// <param name="data">Theme Me data</param>
        /// <returns>A Me</returns>
        public Me DeserializeGet(string data)
        {
            //GET /v1/me
            return JsonConvert.DeserializeObject<Me>(data);

        }
    }
}
