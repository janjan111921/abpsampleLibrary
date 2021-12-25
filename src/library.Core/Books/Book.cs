using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace library.Books
{
    [Table("Book")]
    public class Book: FullAuditedEntity,IMustHaveTenant
    {
        [Required]
        public string Title { get; set; }
        [AllowNull]
        public DateTime ReleaseDate { get; set; }
        public string PublisherName { get; set; }
        [AllowNull]
        public DateTime PublishDate { get; set; }
        public int TotalPages { get; set; }
        public int TenantId { get; set; }
    }
}
