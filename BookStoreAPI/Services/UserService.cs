using AutoMapper;
using BookStoreAPI.Database;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task AddNewUserAsync(UserCreateDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> UserLoginAsync(LoginDto loginDto);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepo _userReo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userReo, IMapper mapper)
        {
            _mapper = mapper;
            _userReo = userReo;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userReo.GetUserByIdAsync(id);
            return new UserDto
            {
                Id = id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role,
            };
        }

        public async Task<UserDto> UserLoginAsync(LoginDto loginDto)
        {
            var user = await _userReo.LoginAsync(loginDto.Email, loginDto.Password);
            
            if(user == null)
            {
                return null;
                
            }
            
            return _mapper.Map<UserDto>(user);


        }

        public async Task AddNewUserAsync(UserCreateDto userDto)
        {
            var user = new User 
            { 
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                Role = userDto.Role,
            };
            await _userReo.AddUserAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userReo.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

    }
}
