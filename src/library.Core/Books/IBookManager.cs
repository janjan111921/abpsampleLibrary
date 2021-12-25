using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Books
{
    public interface IBookManager
    {
        IEnumerable<Book> GetAll();
        void Create(Book input);
        void Update(Book input);
        void Delete(int id);
    }
}
