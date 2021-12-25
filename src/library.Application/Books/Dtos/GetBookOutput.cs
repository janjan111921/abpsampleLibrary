using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Books.Dtos
{
    public class GetBookOutput
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PublisherName { get; set; }
        public DateTime PublishDate { get; set; }
        public int TotalPages { get; set; }
        public int? TenantId { get; set; }
    }
}
