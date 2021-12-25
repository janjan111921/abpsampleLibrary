using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace library.Books.Dtos
{
    public class BookMapProfile : Profile
    {
        public BookMapProfile()
        {
            CreateMap<Book, CreateOrEditBook>();
            CreateMap<Book, GetBookOutput>();
        }
    }
}
