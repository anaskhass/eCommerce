using System;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace eCommarce.DAL.DTO.Responses
{
	public class ProdectResponse
	{
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public string MainImage { get; set; }


        public string MainImageURL => $"https://localhost:7244/Images/{MainImage}";

    }
}

