using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using library.Authorization;
using library.Books.Dtos;

namespace library.Books
{
    [AbpAuthorize(PermissionNames.Pages_Books)]
    public class BookAppService: ApplicationService,  IBookAppService
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IBookManager _bookManager;

        public BookAppService(IObjectMapper objectMapper, IBookManager bookManager)
        {
            _objectMapper = objectMapper;
            _bookManager = bookManager;
        }

        public async Task<PagedResultDto<GetBookOutputList>> GetAll(PageBookResultRequestDto input)
        {
            var getBooks = _bookManager.GetAll().WhereIf(!string.IsNullOrEmpty(input.filter),
                e => e.Title.ToLower().Contains(input.filter.ToLower()) ||
                     e.PublisherName.ToLower().Contains(input.filter.ToLower()));

            var filterBooks = getBooks.Skip(input.SkipCount).Take(input.MaxResultCount);

            var getBookOutput = from x in filterBooks
                select new GetBookOutputList()
                {
                    Book = _objectMapper.Map<GetBookOutput>(x)
                };
            return new PagedResultDto<GetBookOutputList>()
            {
                Items = getBookOutput.ToList(),
                TotalCount = getBookOutput.Count()
            };
        }

        public async Task CreateOrEdit(CreateOrEditBook input)
        {
            if (input.TenantId == null)
            {
                input.TenantId = AbpSession.TenantId;
            }

            var book = _objectMapper.Map<Book>(input);
            if (input.Id == null)
            {
                _bookManager.Create(book);
            }
            else
            {
                _bookManager.Update(book);
            }
        }

        public Task<CreateOrEditBook> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            _bookManager.Delete(id);
        }
    }
}
