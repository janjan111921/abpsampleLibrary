using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace library.Books.Dtos
{
    public class PageBookResultRequestDto : PagedResultRequestDto
    {
        public string filter { get; set; }
    }
}
