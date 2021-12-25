using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using library.Books.Dtos;

namespace library.Books
{
    public interface IBookAppService
    {
        Task<PagedResultDto<GetBookOutputList>> GetAll(PageBookResultRequestDto input);
        Task CreateOrEdit(CreateOrEditBook input);
        Task<CreateOrEditBook> GetBookById(int id);
        Task Delete(int id);

    }
}
