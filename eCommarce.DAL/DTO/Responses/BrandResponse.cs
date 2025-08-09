using System;
using System.Text.Json.Serialization;

namespace eCommarce.DAL.DTO.Responses
{
	public class BrandResponse
	{
        public int Id { get; set; }

        public string Name { get; set; }



        [JsonIgnore]
        public string MainImage { get; set; }


        public string MainImageURL => $"https://localhost:7244/Images/{MainImage}";


    }
}

