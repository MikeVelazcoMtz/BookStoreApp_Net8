using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Models;
using BookStoreApp.API.Models.User;

namespace BookStoreApp.API.Configurations
{

}

class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<AuthorCreateDTO, Author>().ReverseMap();
        CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
        CreateMap<AuthorReadOnlyDTO, Author>().ReverseMap();

        // CreateMap<BookReadonlyDTO, Book>().ReverseMap();
        CreateMap<Book, BookReadonlyDTO>()
            .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

        CreateMap<Book, BookDetailsDTO>()
            .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

        CreateMap<BookCreateDTO, Book>().ReverseMap();
        CreateMap<BookUpdateDTO, Book>().ReverseMap();
        CreateMap<ApiUser, UserDTO>().ReverseMap();
    }
}