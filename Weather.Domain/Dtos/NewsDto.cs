using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather.Domain.Dtos
{
    public class NewsDto
    {
        public string? Author { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Link { get; set; }

        [JsonPropertyName("image_url")]
        public string? UrlToImage { get; set; }
        
        [JsonPropertyName("pubDate")]
        public DateTime? PublishedAt { get; set; }

        public string? Content { get; set; }
    }
}
