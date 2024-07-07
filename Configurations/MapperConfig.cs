using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Models;

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
    }
}