using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
        }
    }
}
