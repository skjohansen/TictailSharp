using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Theme;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Theme repository
    /// </summary>
    public class ThemeResource : IThemeResource, IStore
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Theme repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Theme from</param>
        public ThemeResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        /// <summary>
        /// Get Theme from Tictail API
        /// </summary>
        /// <returns>A Theme</returns>
        public Theme Get()
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid product Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/theme", Method.GET);
            request.AddUrlSegment("storeId", StoreId);

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
        /// ID of store to fetch Theme from
        /// </summary>
        public string StoreId { get; set; }


        /// <summary>
        /// Deserilize the Theme data fetched from the Tictail API
        /// </summary>
        /// <param name="data">Theme JSON data</param>
        /// <returns>A Theme</returns>
        public Theme DeserializeGet(string data)
        {
            //GET /v1/stores/<store_id>/theme
            return JsonConvert.DeserializeObject<Theme>(data);
        }
    }
}
