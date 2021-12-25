using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;

namespace library.Books
{
    public class BookManager : IBookManager
    {
        private readonly IRepository<Book, int> _bookRepository;
        public BookManager(IRepository<Book, int> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Create(Book input)
        {
            _bookRepository.Insert(input);
        }

        public void Update(Book input)
        {
            _bookRepository.Update(input);
        }

        public void Delete(int id)
        {
            var book = _bookRepository.FirstOrDefault(e => e.Id == id);
            if (book != null)
            {
                _bookRepository.Delete(id);
            }
            else
            {
                throw new UserFriendlyException("No Product to Delete");
            }
        }
    }
}
