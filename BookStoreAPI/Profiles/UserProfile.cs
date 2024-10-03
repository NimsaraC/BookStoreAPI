using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
