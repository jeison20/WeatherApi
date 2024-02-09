using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Dtos
{
    public class NewsDataDto
    {

        public string? Status { get; set; }
        public int? TotalResults { get; set; }
        public List<NewsDto>? Results { get; set; }

    }
}
